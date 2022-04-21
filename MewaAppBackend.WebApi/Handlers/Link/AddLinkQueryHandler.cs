using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.Services.Thumbnail;
using MewaAppBackend.WebApi.Queries.Link;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class AddLinkQueryHandler : IRequestHandler<AddLinkCommand, AddLinkCommandResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPageThumbnailService _pageThumbnailService;

        public AddLinkQueryHandler(IUnitOfWork unitOfWork, IPageThumbnailService pageThumbnailService)
        {
            this.unitOfWork = unitOfWork;
            _pageThumbnailService = pageThumbnailService;
        }
        public async Task<AddLinkCommandResult> Handle(AddLinkCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<Model.Model.Link>();
            var link = new Model.Model.Link
            {
                Url = request.Url,
                Name = request.Name,
                Description = request.Description,
                ExpiryDate = request.ExpiryDate,
                OwnerId = request.OwnerId,
                Tags = unitOfWork.Repository<Model.Model.Tag>().GetAll().Where(t => request.Tags.Contains(t.Id)).ToList(),
                Groups = unitOfWork.Repository<Model.Model.Group>().GetAll().Where(t => request.Groups.Contains(t.Id)).ToList(),

            };
            var newLinkFromDb = repository.Add(link);
            unitOfWork.SaveChanges();

            var thumbnailId = await _pageThumbnailService.GetPageThumbnail(newLinkFromDb.Id, request.Url);
            newLinkFromDb.ThumbnailId = thumbnailId;
            repository.Edit(newLinkFromDb);
            unitOfWork.SaveChanges();

            return new AddLinkCommandResult { Success = true };
        }
    }
}
