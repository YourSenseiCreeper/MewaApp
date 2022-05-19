namespace MewaAppBackend.Model.Model
{
    public class GroupPrivilage
    {
        public const short Admin = 777;
        public const short Reader = 111;
    }

    public class GroupUser
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public short Privilage { get; set; } // "777" -> admin "111" read only

        public bool IsAdmin { get { return Privilage == 777; } }
    }
}
