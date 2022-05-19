using Microsoft.AspNetCore.Identity;

namespace MewaAppBackend.Model.Model
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Groups = new HashSet<GroupUser>();
        }
        public File Avatar { get; set; }
        public virtual ICollection<GroupUser> Groups { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}
