namespace MewaAppBackend.Model.Model
{
    public class GroupUser
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
