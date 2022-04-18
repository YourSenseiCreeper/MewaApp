namespace MewaAppBackend.Services.Thumbnail
{
    public interface IPageThumbnailService
    {
        Task<int> GetPageThumbnail(int linkId, string url);
    }
}