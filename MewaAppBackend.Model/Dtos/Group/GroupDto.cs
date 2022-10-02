using MewaAppBackend.Model.Dtos.Link;

namespace MewaAppBackend.Model.Dtos.Group
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MicroLinkDto> Links { get; set; }
        public IEnumerable<MicroGroupDto> Groups { get; set; }
    }
}
 