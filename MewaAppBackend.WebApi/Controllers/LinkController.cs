using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Link;
using MewaAppBackend.WebApi.Handlers.Link;
using MewaAppBackend.WebApi.Queries;
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

        [HttpDelete]
        public async Task<DeleteLinkCommandResult> Delete(int id)
        {
            return await _mediator.Send(new DeleteLinkCommand { Id = id });
        }
    }
}
