using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, CreateGroupCommandResult>
    {
        private readonly IRepository<Model.Model.Link> linkRepository;
        private readonly IRepository<Model.Model.User> userRepository;
        private readonly IRepository<Model.Model.Tag> tagRepository;
        protected readonly IMapper _mapper;
        private readonly Context _context;
        public CreateGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, Context context)
        {
            linkRepository = unitOfWork.Repository<Model.Model.Link>();
            userRepository = unitOfWork.Repository<Model.Model.User>();
            tagRepository = unitOfWork.Repository<Model.Model.Tag>();
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateGroupCommandResult> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var links = linkRepository.GetAll().Where(l => request.Links.Contains(l.Id)).ToList();
            var tags = tagRepository.GetAll().Where(t => request.Tags.Contains(t.Id)).ToList();
            //var users = userRepository.GetAll().Where(u => request.Users.Contains(u.Id))
            //    .Select(u => new GroupUser { UserId = u.Id, GroupId = group.Id }).ToList();

            // sender is admin
            //var selectedUsers = new List<GroupUser>
            //{
            //    new GroupUser { User = null, Privilage = GroupPrivilage.Admin } // todo: attach current user
            //};
            //selectedUsers.AddRange(users.Select(u => new GroupUser { User = u, Privilage = GroupPrivilage.Reader }));

            var group = new Model.Model.Group
            {
                Name = request.Name,
                RedirectURL = request.RedirectURL,
                IsFolder = request.IsFolder,
                Links = links,
                Tags = tags,
            };

            var newGroup = _context.Group.Add(group).Entity;
            newGroup.Users = userRepository.GetAll().Where(u => request.Users.Contains(u.Id))
                .Select(u => new GroupUser { UserId = u.Id, GroupId = newGroup.Id, Privilage = 111 }).ToList();

            _context.SaveChanges();

            return new CreateGroupCommandResult { Success = true };
        }
    }
}
