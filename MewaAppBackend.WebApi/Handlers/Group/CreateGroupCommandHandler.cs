using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        Task<Unit> IRequestHandler<CreateGroupCommand, Unit>.Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            Model.Model.Group group = new()
            {
                Id = request.Id,
                Name = request.Name,
                RedirectURL = request.RedirectURL,
                IsFolder = request.IsFolder,
                Links = request.Links,
                Tags = request.Tags,
                Users = request.Users
            };

            unitOfWork.Repository<Model.Model.Group>().Add(group);
            unitOfWork.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
