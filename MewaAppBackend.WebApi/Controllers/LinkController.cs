using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands;
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
        private readonly IUnitOfWork unitOfWork;

        public LinkController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetAllLinks()
        {
            var request = new GetAllLinksQuery();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("GetLinkById")]
        public async Task<Link> GetLinkById(int id)
        {
            return await _mediator.Send(new GetLinkByIdQuery { Id = id });
        }


        [HttpPost ("Add")]
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
