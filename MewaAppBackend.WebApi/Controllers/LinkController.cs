using MediatR;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Link;
using MewaAppBackend.WebApi.Extentions;
using MewaAppBackend.WebApi.Handlers.Link;
using MewaAppBackend.WebApi.Queries;
using MewaAppBackend.WebApi.Queries.Link;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetAllLinks()
        {
            var request = new GetAllLinksQuery();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("GetByUser")]
        public async Task<ActionResult<IEnumerable<Link>>> GetUserLinks()
        {
            var userId = this.GetUserGuidFromRequest();
            var result = await _mediator.Send(new GetUserLinksQuery { UserId = userId });

            return Ok(result);
        }

        [HttpGet("GetLinkById")]
        public async Task<LinkDto> GetLinkById(int id)
        {
            return await _mediator.Send(new GetLinkByIdQuery { Id = id });
        }


        [HttpPost("Add")]
        public async Task<AddLinkCommandResult> AddLink([FromBody] AddLinkDto dto)
        {
            var userId = this.GetUserGuidFromRequest();
            if (userId == null)
            {
                return new AddLinkCommandResult { Message = "You are not logged in", Success = false };
            }

            var command = new AddLinkCommand
            {
                Url = dto.Url,
                Name = dto.Name,
                Description = dto.Description,
                OwnerId = userId,
                Tags = dto.Tags,
                Groups = dto.Groups
            };
            return await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task<DeleteLinkCommandResult> Delete([FromBody] DeleteLinkCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<EditLinkCommandResult> Edit([FromBody] EditLinkCommand dto)
        {
            var userId = this.GetUserGuidFromRequest();
            if (userId == null)
            {
                return new EditLinkCommandResult { Message = "You are not logged in", Success = false };
            }

            var command = new EditLinkCommand
            {
                Id = dto.Id,
                Url = dto.Url,
                Name = dto.Name,
                Description = dto.Description,
                OwnerId = userId,
                Tags = dto.Tags,
                Groups = dto.Groups
            };
            return await _mediator.Send(command);
        }
    }
}
