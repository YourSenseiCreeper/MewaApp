using MewaAppBackend.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MewaAppBackend.Model.Model
{
    public class GroupUser
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Privilage Privilage { get; set; }

        [NotMapped]
        public bool IsAdmin { get { return Privilage == Privilage.Admin; } }

        [NotMapped]
        public bool IsOwner { get { return Privilage == Privilage.Owner; } }
    }
}
