using MewaAppBackend.Model.Dtos.Link;

namespace MewaAppBackend.Model.Dtos.Group
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MewaElementDto> Elements { get; set; }
    }
}
 