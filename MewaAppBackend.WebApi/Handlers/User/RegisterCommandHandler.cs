using MediatR;
using MewaAppBackend.Services.User;
using MewaAppBackend.WebApi.Handlers.User;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
    {
        private readonly IUserCreationService _userCreationService;
        public RegisterCommandHandler(IUserCreationService userCreationService)
        {
            _userCreationService = userCreationService;
        }

        public async Task<RegisterCommandResult> Handle([FromBody] RegisterCommand request, CancellationToken cancellationToken)
        {
            var response = new RegisterCommandResult { Success = false };
            if (string.IsNullOrWhiteSpace(request.Password))
                return response;

            var user = new Model.Model.User
            {
                UserName = request.UserName,
                Email = request.Email,
            };
            var identity = await _userCreationService.HandleRegister(user, request.Password);
            if (identity == null)
                return response;

            response.Success = true;
            return response;
        }
    }
}
