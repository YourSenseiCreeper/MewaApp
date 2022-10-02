using MediatR;
using MewaAppBackend.Model.Dtos.Tag;
using MewaAppBackend.WebApi.Commands.Tag;
using MewaAppBackend.WebApi.Queries.Tag;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<IEnumerable<TagDto>> GetAll(string tagQuery, int amount)
        {
            return await _mediator.Send(new GetAllTagsQuery { TagQuery = tagQuery, Amount = amount });
        }

        [HttpGet("{id}")]
        public async Task<TagDto> GetById(int id)
        {
            return await _mediator.Send(new GetTagByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTagCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _mediator.Send(new DeleteTagCommand { Id = id });
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditTagCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
