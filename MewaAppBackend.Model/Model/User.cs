using Microsoft.AspNet.Identity.EntityFramework;

namespace MewaAppBackend.Model.Model
{
    public class User : IdentityUser
    {
        public int FileId { get; set; }

        public File File { get; set; }
        public IList<GroupUser> GroupUsers { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<Link> Links { get; set; }
    }
}
