﻿namespace MewaAppBackend.Model.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public User User { get; set; }
        public IList<GroupTag> GroupTags { get; set; }
    }
}
