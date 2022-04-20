using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Tag;

namespace MewaAppBackend.WebApi.Handlers.Tag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, DeleteTagCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTagCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteTagCommandResult> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Model.Model.Tag>();
            var tag = repository.GetDetail(t => t.Id == request.Id);

            if (tag == null)
            {
                return new DeleteTagCommandResult { Message = $"Tag o id {request.Id} nie istnieje!", Success = false };
            }

            repository.Delete(tag);
            _unitOfWork.SaveChanges();

            return new DeleteTagCommandResult { Success = true };
        }
    }
}
