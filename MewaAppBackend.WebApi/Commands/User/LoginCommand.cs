using MediatR;
using MewaAppBackend.Model.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class LoginCommand : IRequest<ActionResult<TokenDTO>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
