using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Link;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class DeleteLinkCommandHandler : IRequestHandler<DeleteLinkCommand, DeleteLinkCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteLinkCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<DeleteLinkCommandResult> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<Model.Model.Link>();
            var entity = repository.GetAllIncluding(l => l.Tags, l => l.Groups).FirstOrDefault(l => l.Id == request.Id);

            if (entity == null)
                return new DeleteLinkCommandResult { Message = $"Link o id: {request.Id} nie istnieje", Success = false };

            entity.Groups.Clear();
            entity.Tags.Clear();
            repository.Delete(entity);
            unitOfWork.SaveChanges();

            return new DeleteLinkCommandResult { Success = true };
        }
    }
}
