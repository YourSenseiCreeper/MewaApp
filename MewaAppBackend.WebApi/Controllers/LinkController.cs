using MediatR;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Queries.List;
using MewaAppBackend.WebApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController<T> : ControllerBase where T : Entity
    {
        private readonly IMediator _mediator;
        private GenericUnitOfWork uow = null;

        public LinkController(IMediator mediator, GenericUnitOfWork _uow)
        {
            this.uow = _uow;
            _mediator = mediator;
        }

        [HttpGet(Name = "Index")]
        public async Task<ActionResult<List<Link>>> Index()
        {
            var request = new IndexQuery();

            var result = await _mediator.Send(request);

            return result;
        }
    }
}
