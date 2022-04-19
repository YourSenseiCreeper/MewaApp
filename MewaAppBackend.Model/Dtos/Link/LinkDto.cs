using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Model.Dtos.Link
{
    public class LinkDto : Entity
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string OwnerId { get; set; }
        public string ThumbnailContent { get; set; }
        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<GroupDto> Groups { get; set; }
    }
}
