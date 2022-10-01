using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Link;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class EditLinkCommandHandler : IRequestHandler<EditLinkCommand, IActionResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public EditLinkCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Handle(EditLinkCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<Model.Model.Link>();
            var entity = repository.GetAllIncluding(l => l.Tags).FirstOrDefault(l => l.Id == request.Id);

            if (entity == null)
                return new BadRequestObjectResult($"Link with id: {request.Id} dose not exist");

            MapToLink(entity, request);
            unitOfWork.SaveChanges();

            return new OkResult();
        }

        private Model.Model.Link MapToLink(Model.Model.Link entity, EditLinkCommand request)
        {
            var tagsRepository = unitOfWork.Repository<Model.Model.Tag>();
            var groupsRepository = unitOfWork.Repository<Model.Model.Group>();

            entity.Url = request.Url;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.ExpiryDate = request.ExpiryDate;
            entity.OwnerId = request.OwnerId;
            entity.Tags = tagsRepository.GetAll().Where(t => request.Tags.Contains(t.Id)).ToList();

            return entity;
        }
    }
}
