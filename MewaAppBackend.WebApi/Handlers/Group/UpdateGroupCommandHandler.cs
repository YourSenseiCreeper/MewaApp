using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Model.Model.Group> groupRepository;
        private readonly IRepository<Model.Model.Link> linkRepository;
        private readonly IRepository<Model.Model.User> userRepository;
        private readonly IRepository<Model.Model.Tag> tagRepository;
        protected readonly IMapper _mapper;
        public UpdateGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            groupRepository = unitOfWork.Repository<Model.Model.Group>();
            linkRepository = unitOfWork.Repository<Model.Model.Link>();
            userRepository = unitOfWork.Repository<Model.Model.User>();
            tagRepository = unitOfWork.Repository<Model.Model.Tag>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = groupRepository.GetAllIncluding(g => g.Links, g => g.Tags, g => g.Users)
                .FirstOrDefault(g => g.Id == request.Id);

            if (group == null)
                return Unit.Value;

            var links = linkRepository.GetAll().Where(l => request.Links.Contains(l.Id)).ToList();
            var tags = tagRepository.GetAll().Where(t => request.Tags.Contains(t.Id)).ToList();
            var users = userRepository.GetAll().Where(u => request.Users.Contains(u.Id))
                .Select(u => new GroupUser { UserId = u.Id, GroupId = group.Id}).ToList();

            group.Id = request.Id;
            group.Name = request.Name;
            group.RedirectURL = request.RedirectURL;
            group.IsFolder = request.IsFolder;
            group.Links = links;
            group.Tags = tags;
            group.Users = users;

            groupRepository.Edit(group);
            unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }
}
