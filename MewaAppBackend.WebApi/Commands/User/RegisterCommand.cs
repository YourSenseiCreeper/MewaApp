using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class RegisterCommand : IRequest<IActionResult>
    {
        [Required]
        [FromBody]
        public string UserName { get; set; }

        [Required]
        [FromBody]
        public string Email { get; set; }

        [Required]
        [FromBody]
        public string Password { get; set; }
    }
}
