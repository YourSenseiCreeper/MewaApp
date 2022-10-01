using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class LoginCommand : IRequest<ActionResult<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
