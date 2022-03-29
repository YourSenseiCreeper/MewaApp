namespace MewaAppBackend.Model.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string RedirectURL { get; set; }
        public string Name { get; set; }
        public bool IsFolder { get; set; }

        public ICollection<Link> Links { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
