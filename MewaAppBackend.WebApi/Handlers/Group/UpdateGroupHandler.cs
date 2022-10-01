using AutoMapper;
using MediatR;
using MewaAppBackend.Business.EntityFramework;
using MewaAppBackend.Business.Repository;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Dtos.User;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class UpdateGroupHandler : IRequestHandler<UpdateGroupCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Model.Model.Group> groupRepository;
        protected readonly IMapper _mapper;
        private readonly Context _context;
        public UpdateGroupHandler(IUnitOfWork unitOfWork, IMapper mapper, Context context)
        {
            this.unitOfWork = unitOfWork;
            groupRepository = unitOfWork.Repository<Model.Model.Group>();
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = groupRepository.GetAllIncluding(g => g.Links, g => g.Tags, g => g.Users)
                .FirstOrDefault(g => g.Id == request.Id);

            if (group == null)
                return Unit.Value;

            group.Id = request.Id;
            group.Name = request.Name;
            group.IsFolder = request.IsFolder;
            group.Links = CompareAndProduceResults(group.Links, request.Links);
            group.Tags = CompareAndProduceResults(group.Tags, request.Tags);
            group.Users = CompareAndProduceResultUsers(group.Users, request.Users);

            groupRepository.Edit(group);
            unitOfWork.SaveChanges();

            return Unit.Value;
        }

        private List<GroupUser> CompareAndProduceResultUsers(IEnumerable<GroupUser> source, IEnumerable<GroupUserDto> targetUsers)
        {
            var sourceLinksIds = source.Select(l => l.UserId);
            var targetUsersIds = targetUsers.Select(t => t.UserId).ToList();
            var differenceUsersIds = targetUsersIds.Except(sourceLinksIds);

            var existingUsersIds = sourceLinksIds.Intersect(targetUsersIds);
            var existingUsers = source.Where(l => existingUsersIds.Contains(l.UserId)).ToList();
            foreach (var existingUser in existingUsers)
            {
                existingUser.Privilage = targetUsers.First(u => u.UserId == existingUser.UserId).Privilage;
            }

            // czy użytkownik ma uprawnienia do modyfikowania uprawnień innych?

            var newUsers = targetUsers.Where(u => differenceUsersIds.Any(d => u.UserId == d))
                .Select(u => new GroupUser { GroupId = u.GroupId, UserId = u.UserId, Privilage = Model.Enum.Privilage.User }).ToList();
            // we remove things by not picking to the savelist
            existingUsers.AddRange(newUsers);

            return existingUsers;
        }

        private List<T> CompareAndProduceResults<T>(IEnumerable<T> source, IEnumerable<int> targetIds) where T : Entity
        {
            var sourceLinksIds = source.Select(l => l.Id);
            var differenceLinkIds = targetIds.Except(sourceLinksIds);
            var notModifiedLinksIds = sourceLinksIds.Intersect(targetIds);
            var notModified = source.Where(l => notModifiedLinksIds.Contains(l.Id)).ToList();

            var addedLinks = differenceLinkIds.Where(l => targetIds.Contains(l)).ToList();
            // we remove things by not picking to the savelist
            var newLinksFromDb = _context.Set<T>().Where(l => addedLinks.Contains(l.Id)).ToList();
            notModified.AddRange(newLinksFromDb);

            return notModified;
        }
    }
}
