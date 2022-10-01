using MediatR;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.WebApi.Commands.Tag;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Tag
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, IActionResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTagHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Model.Model.Tag>();
            var tag = repository.GetDetail(t => t.Id == request.Id);

            if (tag == null)
                return new BadRequestObjectResult($"Tag with id {request.Id} dose not exist!");

            repository.Delete(tag);
            _unitOfWork.SaveChanges();

            return new OkResult();
        }
    }
}
