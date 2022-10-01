using MediatR;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.WebApi.Commands.Tag;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Tag
{
    public class AddTagHandler : IRequestHandler<AddTagCommand, IActionResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddTagHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Handle(AddTagCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Model.Model.Tag>();

            var userTagCollection = repository.GetAll().Where(t => t.UserId == request.UserId);

            if (userTagCollection.Any(t => t.Name == request.Name))
            {
                return new BadRequestObjectResult("Taq must be uniqe");
            }

            repository.Add(new Model.Model.Tag { UserId = request.UserId, Name = request.Name });
            _unitOfWork.SaveChanges();

            return new OkResult();
        }
    }
}
