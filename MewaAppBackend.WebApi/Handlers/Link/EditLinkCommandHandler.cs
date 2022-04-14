using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Link;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class EditLinkCommandHandler : IRequestHandler<EditLinkCommand, EditLinkCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public EditLinkCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<EditLinkCommandResult> Handle(EditLinkCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<Model.Model.Link>();
            var entity = repository.GetAllIncluding(l => l.Tags, l => l.Groups).FirstOrDefault(l => l.Id == request.Id);

            if (entity == null)
                return new EditLinkCommandResult { Message = $"Link o id: {request.Id} nie istnieje", Success = false };

            MapToLink(entity, request);
            unitOfWork.SaveChanges();

            return new EditLinkCommandResult { Success = true };
        }

        private Model.Model.Link MapToLink(Model.Model.Link entity, EditLinkCommand request)
        {
            var tagsRepository = unitOfWork.Repository<Tag>();
            var groupsRepository = unitOfWork.Repository<Model.Model.Group>();

            entity.Url = request.Url;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.ExpiryDate = request.ExpiryDate;
            entity.OwnerId = request.OwnerId;
            entity.Tags = tagsRepository.GetAll().Where(t => request.Tags.Contains(t.Id)).ToList();
            entity.Groups = groupsRepository.GetAll().Where(g => request.Groups.Contains(g.Id)).ToList();

            return entity;
        }
    }
}
