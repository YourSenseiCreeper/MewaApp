using MediatR;
using MewaAppBackend.Services.User;
using MewaAppBackend.WebApi.Handlers.User;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ActionResult<LoginCommandResult>>
    {
        private readonly IUserCreationService _userCreationService;
        public LoginCommandHandler(IUserCreationService userCreationService)
        {
            _userCreationService = userCreationService;
        }

        public async Task<ActionResult<LoginCommandResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await _userCreationService.HandleLogin(request.Email, request.Password);
            if (token == null)
                return new BadRequestObjectResult("User not exists or password didn't match");
            
            return new OkObjectResult(new LoginCommandResult { Token = token });
        }
    }
}
