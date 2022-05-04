using MediatR;
using MewaAppBackend.WebApi.Commands.User;
using MewaAppBackend.WebApi.Handlers.User;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<RegisterCommandResult> Create([FromBody] RegisterCommand command)
        {
            return await _mediator.Send(command, CancellationToken.None);
        }

        [HttpPost("Login")]
        public async Task<LoginCommandResult> Login([FromBody] LoginCommand command)
        {
            return await _mediator.Send(command, CancellationToken.None);
        }

        [HttpGet("Exists")]
        public async Task<bool> HasUserExists(string username)
        {
            return await _mediator.Send(new HasUserExistsCommand { UserName = username }, CancellationToken.None);
        }
    }
}
