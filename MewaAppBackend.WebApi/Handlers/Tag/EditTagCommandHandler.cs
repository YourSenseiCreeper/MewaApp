using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Tag;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Tag
{
    public class EditTagCommandHandler : IRequestHandler<EditTagCommand, IActionResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditTagCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Handle(EditTagCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Model.Model.Tag>();

            var tag = repository.GetDetail(t => t.Id == request.Id);
            if (tag == null)
            {
                return new BadRequestObjectResult($"Tag with id {request.Id} does not exist");
            }

            tag.Name = request.Name;
            tag.Description = request.Description;
            tag.UserId = request.UserId;

            repository.Edit(tag);
            _unitOfWork.SaveChanges();

            return new OkResult();
        }
    }
}
