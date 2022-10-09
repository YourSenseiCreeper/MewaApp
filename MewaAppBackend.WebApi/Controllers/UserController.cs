using MediatR;
using MewaAppBackend.Model.Dtos.User;
using MewaAppBackend.WebApi.Commands.User;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] RegisterCommand command)
        {
            return await _mediator.Send(command, CancellationToken.None);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<TokenDTO>> Login([FromBody] LoginCommand command)
        {
            return await _mediator.Send(command, CancellationToken.None);
        }
    }
}
