using MediatR;
using MewaAppBackend.Model.Dtos.Dashboard;
using MewaAppBackend.WebApi.Extentions;
using MewaAppBackend.WebApi.Queries.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Geting all links and groups for user
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByUser")]
        public async Task<DashboardDto> GetByUser(string username)
        {
            var userId = this.GetUserGuidFromRequest();
            return await _mediator.Send(new GetDashboardByUserQuery { Username = username, UserId = userId });
        }
    }
}
