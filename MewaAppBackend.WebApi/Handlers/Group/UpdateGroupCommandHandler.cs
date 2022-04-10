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
            userRepository = unitOfWork.Repository<User>();
            tagRepository = unitOfWork.Repository<Tag>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = groupRepository.GetDetail(g => g.Id == request.Id);

            group.Id = request.Id;
            group.Name = request.Name;
            group.RedirectURL = request.RedirectURL;
            group.IsFolder = request.IsFolder;
            group.Links = _mapper.Map<ICollection<Model.Model.Link>>(request.Links);
            group.Tags = _mapper.Map<ICollection<Tag>>(request.Tags);
            group.Users = _mapper.Map<ICollection<User>>(request.Users);

            groupRepository.Edit(group);
            unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }
}
