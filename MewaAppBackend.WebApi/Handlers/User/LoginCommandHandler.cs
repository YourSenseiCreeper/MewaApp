using MediatR;
using MewaAppBackend.Services.User;
using MewaAppBackend.WebApi.Handlers.User;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
    {
        private readonly IUserCreationService _userCreationService;
        public LoginCommandHandler(IUserCreationService userCreationService)
        {
            _userCreationService = userCreationService;
        }

        public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await _userCreationService.HandleLogin(request.Email, request.Password);
            if (token == null)
            {
                return new LoginCommandResult { Message = "User not exists or password didn't match", Success = false };
            }
            return new LoginCommandResult { Token = token, Success = true };
        }
    }
}
