using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
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

            unitOfWork.Repository<Model.Model.Group>().Edit(group);
            unitOfWork.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
