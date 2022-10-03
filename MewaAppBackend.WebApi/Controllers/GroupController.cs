using MediatR;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.WebApi.Commands.Group;
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
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddGroupToGroup")]
        public async Task<ActionResult<MicroGroupDto>> AddGroupToGroup(AddGroupToGroupCommand comand)
        {
            return Ok(await _mediator.Send(comand));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateGroupCommand updateGroupCommand)
        {
            await _mediator.Send(updateGroupCommand);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGroupCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("GetGroup")]
        public async Task<ActionResult<GroupDto>> Get([FromQuery] GetDetailGroupQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("GetUserGroup")]
        public async Task<ActionResult<GroupDto>> GetUserGroup()
        {
            var userId = this.GetUserGuidFromRequest();
            if (userId == null)
                return new BadRequestObjectResult("User dose not exist");

            return await _mediator.Send(new GetDashboardByUserQuery { UserId = userId });
        }
    }
}
