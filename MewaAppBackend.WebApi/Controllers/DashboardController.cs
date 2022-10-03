using MediatR;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.WebApi.Extentions;
using MewaAppBackend.WebApi.Queries.Group;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<ActionResult<GroupDto>> GetByUser()
        {
            var userId = this.GetUserGuidFromRequest();
            if (userId == null)
                return new BadRequestObjectResult("User dose not exist");

            return await _mediator.Send(new GetDashboardByUserQuery { UserId = userId });
        }
    }
}
