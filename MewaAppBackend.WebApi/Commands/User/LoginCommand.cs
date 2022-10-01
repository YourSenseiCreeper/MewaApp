using MediatR;
using MewaAppBackend.WebApi.Handlers.User;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class LoginCommand : IRequest<ActionResult<LoginCommandResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
