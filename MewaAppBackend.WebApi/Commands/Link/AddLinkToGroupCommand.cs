using MediatR;
using MewaAppBackend.Model.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Link
{
    public class AddLinkToGroupCommand : IRequest<ActionResult<MewaElementDto>>
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int GroupId { get; set; }
    }
}
