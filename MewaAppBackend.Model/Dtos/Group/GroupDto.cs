using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Dtos.Tag;
using MewaAppBackend.Model.Dtos.User;

namespace MewaAppBackend.Model.Dtos.Group
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<MicroLinkDto> Links { get; set; }
        public IEnumerable<AddUserToSomething> Users { get; set; }
    }
}
