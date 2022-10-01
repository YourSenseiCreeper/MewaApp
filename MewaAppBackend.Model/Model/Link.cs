namespace MewaAppBackend.Model.Model
{
    public class Link: Entity
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public User Owner { get; set; }
        public string OwnerId { get; set; }
        public DbImage? Thumbnail { get; set; }
        public int? ThumbnailId { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public Group Group { get; set; }
    }
}
