using MediatR;
using MewaAppBackend.Model.Dtos.Dashboard;

namespace MewaAppBackend.WebApi.Queries.Dashboard
{
    public class GetDashboardByUserQuery : IRequest<DashboardDto>
    {
        public string Username { get; set; }
        public string UserId { get; set; }
    }
}
