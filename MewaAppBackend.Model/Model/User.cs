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
        public IEnumerable<GroupUser> Groups { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}
