using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Link
{
    public class DeleteLinkCommand : IRequest<IActionResult>
    {
        public int Id { get; set; }
    }
}
