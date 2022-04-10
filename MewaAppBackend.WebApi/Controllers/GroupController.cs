using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Group;
using MewaAppBackend.WebApi.Queries.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork unitOfWork;

        public GroupController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetAllGroups()
        {
            var request = new GetAllGroupsQuery();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

/*        [HttpGet]
        public async Task<ActionResult> GetDetailGroup(int id)
        {
            return Ok(await _mediator.Send(new GetDetailGroupQuery { Id = id }));
        }
*/

        [HttpPost]
        public async Task<ActionResult> Create(CreateGroupCommand createGroupCommand)
        {
            return Ok(await _mediator.Send(createGroupCommand));
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
        public async Task<ActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
