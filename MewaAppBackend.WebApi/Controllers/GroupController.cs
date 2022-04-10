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

        [HttpGet("GetAllGroups")]
        public async Task<ActionResult<IEnumerable<Group>>> GetAllGroups()
        {
            var request = new GetAllGroupsQuery();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("GetDetailGroup")]
        public async Task<ActionResult> GetDetailGroup(int id)
        {
            return Ok(await _mediator.Send(new GetDetailGroupQuery { Id = id }));
        }

        [HttpPost("CreateGroup")]
        public async Task<ActionResult> Create(CreateGroupCommand createGroupCommand)
        {
            return Ok(await _mediator.Send(createGroupCommand));
        }

        [HttpPost("TestDataGroup")]
        public async Task<ActionResult> TestData()
        {
            unitOfWork.Repository<Link>().Add(new Link()
            {
                Name = "Name",
                OwnerId = "28ad5b21-258b-4b21-b44a-78fac15a9c37",
                Url = "asd"
            });

            unitOfWork.Repository<Tag>().Add(new Tag()
            {
                Name = "Name",
                UserId = "28ad5b21-258b-4b21-b44a-78fac15a9c37"
            });

            unitOfWork.SaveChanges();

            return Ok();
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
