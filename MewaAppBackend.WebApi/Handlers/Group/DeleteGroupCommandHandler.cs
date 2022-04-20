using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, DeleteGroupCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Model.Model.Group> groupRepository;
        public DeleteGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            groupRepository = unitOfWork.Repository<Model.Model.Group>();
        }

        public async Task<DeleteGroupCommandResult> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = groupRepository.GetDetail(g => g.Id == request.Id);
            if (group == null)
            {
                return new DeleteGroupCommandResult { Message = $"Grupa o id {request.Id} nie istnieje!", Success = false };
            }
            groupRepository.Delete(group);
            unitOfWork.SaveChanges();

            return new DeleteGroupCommandResult { Success = true };
        }
    }
}
