using MediatR;
using MewaAppBackend.Model.Dtos;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.WebApi.Commands.Link;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddLinkToGroup")]
        public async Task<ActionResult<MewaElementDto>> AddLinkToGroup([FromBody] AddLinkToGroupCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteLinkCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<MewaElementDto>> Edit([FromBody] EditLinkCommand dto)
        {
            return await _mediator.Send(dto);
        }
    }
}
