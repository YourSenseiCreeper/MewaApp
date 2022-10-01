using MediatR;
using MewaAppBackend.Business.Repository;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.WebApi.Commands.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand, IActionResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Model.Model.Group> groupRepository;
        public DeleteGroupHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            groupRepository = unitOfWork.Repository<Model.Model.Group>();
        }

        public async Task<IActionResult> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = groupRepository.GetDetail(g => g.Id == request.Id);
            if (group == null)
            {
                return new BadRequestObjectResult($"Group with id {request.Id} dose not exist");
            }
            groupRepository.Delete(group);
            unitOfWork.SaveChanges();

            return new OkResult();
        }
    }
}
