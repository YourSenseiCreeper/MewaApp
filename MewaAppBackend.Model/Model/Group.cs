namespace MewaAppBackend.Model.Model
{
    public class Group
    {
        public int Id { get; set; }
        public int LinkId { get; set; }
        public string RedirectURL { get; set; }
        public string Name { get; set; }
        public bool IsFolder { get; set; }

        public IList<GroupLink> GroupLinks { get; set; }
        public IList<GroupTag> GroupTags { get; set; }
        public IList<GroupUser> GroupUsers { get; set; }

    }
}
