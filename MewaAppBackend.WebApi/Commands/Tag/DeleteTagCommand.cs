using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Tag
{
    public class DeleteTagCommand : IRequest<IActionResult>
    {
        public int Id { get; set; }
    }
}
