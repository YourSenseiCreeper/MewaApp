using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Queries;
using MewaAppBackend.WebApi.Queries.Link;
using System.Linq;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class AddLinkQueryHandler : IRequestHandler<AddLinkCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddLinkQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(AddLinkCommand request, CancellationToken cancellationToken)
        {
            var link = new Model.Model.Link
            {
                Url = request.Url,
                Name = request.Name,
                Description = request.Description,
                ExpiryDate = request.ExpiryDate,
                OwnerId = request.OwnerId,
                ThumbnailId = request.ThumbnailId,
                Tags = unitOfWork.Repository<Tag>().GetAll().Where(t => request.Tags.Contains(t.Id)).ToList(),
                Groups = unitOfWork.Repository<Model.Model.Group>().GetAll().Where(t => request.Groups.Contains(t.Id)).ToList(),

            };
            unitOfWork.Repository<Model.Model.Link>().Add(link);
            return Unit.Value;
        }
    }
}
