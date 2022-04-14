namespace MewaAppBackend.Model.Model
{
    public class Group : Entity
    {
        public Group()
        {
            this.Tags = new HashSet<Tag>();
            this.Links = new HashSet<Link>();
            this.Users = new HashSet<User>();
        }

        public string RedirectURL { get; set; }
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
