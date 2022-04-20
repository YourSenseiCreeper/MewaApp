using MediatR;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Dtos.Tag;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Link;
using MewaAppBackend.WebApi.Commands.Tag;
using MewaAppBackend.WebApi.Handlers.Link;
using MewaAppBackend.WebApi.Handlers.Tag;
using MewaAppBackend.WebApi.Queries;
using MewaAppBackend.WebApi.Queries.Link;
using MewaAppBackend.WebApi.Queries.Tag;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TagDto>> GetAll()
        {
            return await _mediator.Send(new GetAllTagsQuery());
        }

        [HttpGet("{id}")]
        public async Task<TagDto> GetById(int id)
        {
            return await _mediator.Send(new GetTagByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<AddTagCommandResult> Add([FromBody] AddTagCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteTagCommandResult> Delete(int id)
        {
            return await _mediator.Send(new DeleteTagCommand { Id = id });
        }

        [HttpPut]
        public async Task<EditTagCommandResult> Edit([FromBody] EditTagCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
