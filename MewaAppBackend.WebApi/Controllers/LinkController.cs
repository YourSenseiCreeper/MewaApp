using MediatR;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Link;
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

        [HttpGet("GetLinkById")]
        public async Task<LinkDto> GetLinkById(int id)
        {
            return await _mediator.Send(new GetLinkByIdQuery { Id = id });
        }


        [HttpPost("Add")]
        public async Task<Unit> AddLink([FromBody] AddLinkCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<DeleteLinkCommandResult> Delete(int id)
        {
            return await _mediator.Send(new DeleteLinkCommand { Id = id });
        }

        [HttpPut]
        public async Task<EditLinkCommandResult> Edit([FromBody] EditLinkCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
