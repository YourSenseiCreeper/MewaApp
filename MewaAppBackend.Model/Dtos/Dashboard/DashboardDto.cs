using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.Model.Dtos.Link;

namespace MewaAppBackend.Model.Dtos.Dashboard
{
    public class DashboardDto
    {
        public IEnumerable<LinkDto> Links { get; set; }
        public IEnumerable<MicroGroupDto> Groups { get; set; }
        public IEnumerable<LinkDto> SharedLinks { get; set; }
        public IEnumerable<MicroGroupDto> SharedGroups { get; set; }
    }
}
