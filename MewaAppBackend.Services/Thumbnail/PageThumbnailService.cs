using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using System.Net;
using System.Text.RegularExpressions;

namespace MewaAppBackend.Services.Thumbnail
{
    public class PageThumbnailService : IPageThumbnailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PageThumbnailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetPageThumbnail(int linkId, string url)
        {
            string html = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.None;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var hasFoundImage = html.IndexOf("og:image");
            if (hasFoundImage > -1)
            {
                var firstNewlineAfterImageTag = html.IndexOf("/>", hasFoundImage);
                var imageSubstring = html.Substring(hasFoundImage, firstNewlineAfterImageTag);
                var regex = new Regex(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
                var match = regex.Match(imageSubstring);
                if (match.Success)
                {
                    var result = await GetImageAsByteArray(match.Groups[0].Value);
                    var base64Image = Convert.ToBase64String(result);
                    var newImageFromDb = _unitOfWork.Repository<DbImage>().Add(new DbImage { LinkId = linkId, Content = base64Image });
                    _unitOfWork.SaveChanges();
                    return newImageFromDb.Id;
                }
            }
            return 0;
        }

        private async Task<byte[]> GetImageAsByteArray(string urlImage)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(urlImage)
            };
            var response = await client.GetAsync("");

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
