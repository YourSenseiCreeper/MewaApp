using MediatR;
using MewaAppBackend.WebApi.Handlers.User;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class RegisterCommand : IRequest<RegisterCommandResult>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
