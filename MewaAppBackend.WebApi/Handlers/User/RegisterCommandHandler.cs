using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, IActionResult>
    {
        private readonly IUserCreationService _userCreationService;
        private readonly IBusinessFactory _businessFactory;

        public RegisterCommandHandler(IUserCreationService userCreationService, IBusinessFactory businessFactory)
        {
            _userCreationService = userCreationService;
            _businessFactory = businessFactory;
        }

        public async Task<IActionResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = CreateUserFromRequest(request);

            var identity = await _userCreationService.HandleRegister(user, request.Password);
            if (identity == null)
                return new BadRequestObjectResult("New user not created");

            var newGroup = _businessFactory.GroupBusiness.CreatePersonalGroup(user);
            _businessFactory.GroupBusiness.AddOwner(newGroup, user);
            _businessFactory.SaveChanges();

            return new OkResult();
        }

        private Model.Model.User CreateUserFromRequest(RegisterCommand request)
        {
            return new Model.Model.User
            {
                UserName = request.UserName,
                Email = request.Email,
            };
        }
    }
}
