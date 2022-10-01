using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Tag
{
    public class AddTagCommand : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
