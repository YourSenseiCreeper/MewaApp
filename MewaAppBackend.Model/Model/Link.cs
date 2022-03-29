namespace MewaAppBackend.Model.Model
{
    public class Link
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int FileId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpiryDate { get; set; }

        public User User { get; set; }
        public File File { get; set; }
        public IList<GroupLink> GroupLinks { get; set; }
    }
}
