using MediatR;
using MewaAppBackend.Model.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Link
{
    public class EditLinkCommand : IRequest<ActionResult<MewaElementDto>>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int GroupId { get; set; }
    }
}
