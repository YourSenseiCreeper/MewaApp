namespace MewaAppBackend.Model.Model
{
    public class GroupLink
    {
        public int LinkId { get; set; }
        public Link Link { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
