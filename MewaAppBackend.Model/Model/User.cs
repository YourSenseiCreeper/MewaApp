using Microsoft.AspNetCore.Identity;

namespace MewaAppBackend.Model.Model
{
    public class User : IdentityUser
    {
        public File File { get; set; }
        public ICollection<Group> Groups { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<Link> Links { get; set; }
    }
}
