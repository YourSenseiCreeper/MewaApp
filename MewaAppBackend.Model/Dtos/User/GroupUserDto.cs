using MewaAppBackend.Model.Enum;

namespace MewaAppBackend.Model.Dtos.User
{
    public class GroupUserDto
    {
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public Privilage Privilage { get; set; }
    }
}
