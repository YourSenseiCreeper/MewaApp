using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Model.Model.Link> linkRepository;
        private readonly IRepository<Model.Model.User> userRepository;
        private readonly IRepository<Model.Model.Tag> tagRepository;
        protected readonly IMapper _mapper;
        public CreateGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            linkRepository = unitOfWork.Repository<Model.Model.Link>();
            userRepository = unitOfWork.Repository<Model.Model.User>();
            tagRepository = unitOfWork.Repository<Model.Model.Tag>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            Model.Model.Group group = new();

            var links = linkRepository.GetAll().Where(l => request.Links.Contains(l.Id)).ToList();
            var tags = tagRepository.GetAll().Where(t => request.Tags.Contains(t.Id)).ToList();
            var users = userRepository.GetAll().Where(u => request.Users.Contains(u.Id)).ToList();

            group.Name = request.Name;
            group.RedirectURL = request.RedirectURL;
            group.IsFolder = request.IsFolder;
            group.Links = links;
            group.Tags = tags;
            group.Users = users;

            unitOfWork.Repository<Model.Model.Group>().Add(group);
            unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }
}
