namespace MewaAppBackend.Model.Model
{
    public class Tag: Entity
    {
        public Tag()
        {
            this.Groups = new HashSet<Group>();
        }
        public string Name { get; set; }
        public string? Description { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
