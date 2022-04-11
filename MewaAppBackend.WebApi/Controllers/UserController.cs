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
        public async Task<RegisterCommandResult> Create(string userName, string email, string password)
        {
            var command = new RegisterCommand
            {
                UserName = userName,
                Email = email,
                Password = password
            };
            return await _mediator.Send(command, CancellationToken.None);
        }

        [HttpPost("Login")]
        public async Task<LoginCommandResult> Login(string email, string password)
        {
            return await _mediator.Send(new LoginCommand { Email = email, Password = password }, CancellationToken.None);
        }
    }
}
