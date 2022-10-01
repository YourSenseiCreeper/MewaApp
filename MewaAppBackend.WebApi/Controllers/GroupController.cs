using MediatR;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Dtos.Group;
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

        /// <summary>
        /// Geting all groups
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<GroupDto>> GetAll()
        {
            return await _mediator.Send(new GetAllGroupsQuery());
        }
        /// <summary>
        /// Get one group
        /// </summary>
        /// <param name="id"> Id of group that we want go get </param>
        /// <returns> HTTP Response only </returns>
        [HttpGet("GetDetailGroup")]
        public async Task<GroupDto> GetDetailGroup(int id)
        {
            return await _mediator.Send(new GetDetailGroupQuery { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGroupCommand createGroupCommand)
        {
            //var currentUserId = this.GetUserGuidFromRequest();
            //createGroupCommand.Users = new[] { currentUserId };
            return Ok(await _mediator.Send(createGroupCommand));
        }

        [HttpPost("TestDataGroup")]
        public async Task<ActionResult<string>> TestData()
        {
            unitOfWork.Repository<Link>().Add(new Link
            {
                Name = "Name",
                Url = "asd"
            });

            unitOfWork.Repository<Tag>().Add(new Tag
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
        public async Task<IActionResult> Delete([FromBody] DeleteGroupCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
