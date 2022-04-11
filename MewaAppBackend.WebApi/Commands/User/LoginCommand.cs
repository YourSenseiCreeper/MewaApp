using MediatR;
using MewaAppBackend.WebApi.Handlers.User;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class LoginCommand : IRequest<LoginCommandResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
