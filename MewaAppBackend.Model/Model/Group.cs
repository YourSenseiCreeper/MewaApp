namespace MewaAppBackend.Model.Model
{
    public class Group : Entity
    {
        public Group()
        {
            this.Tags = new HashSet<Tag>();
            this.Links = new HashSet<Link>();
            this.Users = new HashSet<GroupUser>();
        }

        public string Name { get; set; }
        public bool IsPersonal { get; set; }
        public IEnumerable<Link> Links { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<GroupUser> Users { get; set; }
        public Group ParentGroup { get; set; }
        public int? ParentGroupId { get; set; }
        public int GroupLvl { get; set; }
    }
}
