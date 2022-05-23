using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.Model.Dtos.Link;

namespace MewaAppBackend.Model.Dtos.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<MicroLinkDto> Links { get; set; }
        public IEnumerable<MicroGroupDto> Groups { get; set; }
    }
}
