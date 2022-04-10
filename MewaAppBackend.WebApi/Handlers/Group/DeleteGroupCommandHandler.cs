using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        Task<Unit> IRequestHandler<DeleteGroupCommand, Unit>.Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = unitOfWork.Repository<Model.Model.Group>().GetDetail(g => g.Id == request.Id);
            unitOfWork.Repository<Model.Model.Group>().Delete(group);
            unitOfWork.SaveChanges();
            return Task.FromResult(Unit.Value);
        }
    }
}
