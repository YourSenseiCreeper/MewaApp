using MediatR;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Services.Thumbnail;
using MewaAppBackend.WebApi.Queries.Link;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class AddLinkHandler : IRequestHandler<AddLinkCommand, IActionResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPageThumbnailService _pageThumbnailService;

        public AddLinkHandler(IUnitOfWork unitOfWork, IPageThumbnailService pageThumbnailService)
        {
            this.unitOfWork = unitOfWork;
            _pageThumbnailService = pageThumbnailService;
        }
        public async Task<IActionResult> Handle(AddLinkCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<Model.Model.Link>();
            var link = new Model.Model.Link
            {
                Url = request.Url,
                Name = request.Name,
                Description = request.Description,
                ExpiryDate = request.ExpiryDate,
                Tags = unitOfWork.Repository<Model.Model.Tag>().GetAll().Where(t => request.Tags.Contains(t.Id)).ToList(),
            };
            var newLinkFromDb = repository.Add(link);
            unitOfWork.SaveChanges();

            var thumbnailId = await _pageThumbnailService.GetPageThumbnail(newLinkFromDb.Id, request.Url);
            newLinkFromDb.ThumbnailId = thumbnailId;
            repository.Edit(newLinkFromDb);
            unitOfWork.SaveChanges();

            return new OkResult();
        }
    }
}
