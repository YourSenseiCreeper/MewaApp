namespace MewaAppBackend.Model.Model
{
    public class Link: Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public File File { get; set; }
        public int? FileId { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
