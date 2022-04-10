﻿using Microsoft.AspNetCore.Identity;

namespace MewaAppBackend.Model.Model
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Groups = new HashSet<Group>();
        }
        public File Avatar { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}
