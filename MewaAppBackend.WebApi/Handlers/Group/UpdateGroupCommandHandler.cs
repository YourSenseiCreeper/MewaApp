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
        protected readonly IMapper _mapper;
        public UpdateGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            groupRepository = unitOfWork.Repository<Model.Model.Group>();
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
            group.Tags = _mapper.Map<ICollection<Model.Model.Tag>>(request.Tags);
            group.Users = _mapper.Map<ICollection<Model.Model.GroupUser>>(request.Users);

            groupRepository.Edit(group);
            unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }
}
