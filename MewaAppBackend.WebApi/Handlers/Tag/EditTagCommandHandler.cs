using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Tag;

namespace MewaAppBackend.WebApi.Handlers.Tag
{
    public class EditTagCommandHandler : IRequestHandler<EditTagCommand, EditTagCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditTagCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EditTagCommandResult> Handle(EditTagCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Model.Model.Tag>();

            var tag = repository.GetDetail(t => t.Id == request.Id);
            if (tag == null)
            {
                return new EditTagCommandResult { Message = $"Tag o id {request.Id} nie istnieje!", Success = false };
            }

            tag.Name = request.Name;
            tag.Description = request.Description;
            tag.UserId = request.UserId;

            repository.Edit(tag);
            _unitOfWork.SaveChanges();

            return new EditTagCommandResult { Success = true };
        }
    }
}
