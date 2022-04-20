using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Tag;

namespace MewaAppBackend.WebApi.Handlers.Tag
{
    public class AddTagCommandHandler : IRequestHandler<AddTagCommand, AddTagCommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddTagCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AddTagCommandResult> Handle(AddTagCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Model.Model.Tag>();

            var userTagCollection = repository.GetAll().Where(t => t.UserId == request.UserId);

            if (userTagCollection.Any(t => t.Name == request.Name))
            {
                return new AddTagCommandResult { Message = "Tag musi być unikalny", Success = false };
            }

            repository.Add(new Model.Model.Tag { UserId = request.UserId, Name = request.Name });
            _unitOfWork.SaveChanges();

            return new AddTagCommandResult { Success = true };
        }
    }
}
