using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Group
{
    public class DeleteGroupCommand : IRequest<IActionResult>
    {
        public int Id { get; set; }
    }
}
