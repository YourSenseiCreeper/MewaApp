using MediatR;
using MewaAppBackend.Model.Dtos.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Queries.Group
{
    public class GetDashboardByUserQuery : IRequest<ActionResult<GroupDto>>
    {
        public string UserId { get; set; }
    }
}
