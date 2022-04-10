using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserCreationService _userCreationService;

        public UserController(IMediator mediator, IUnitOfWork unitOfWork, IUserCreationService userCreationService)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _userCreationService = userCreationService;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> CreateUser(string userName, string email, string password)
        {
            var newUser = new User()
            {
                UserName = userName,
                Email = email,
            };
            _userCreationService.HandleRegister(newUser, password);
            return Ok(newUser);
        }
    }
}
