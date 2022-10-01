using AutoMapper.Configuration.Annotations;
using MediatR;
using MewaAppBackend.Model.Dtos.Tag;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Link
{
    public class AddLinkToGroupCommand: IRequest<IActionResult>
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int GroupId { get; set; }

        [Ignore]
        public string UserId { get; set; }
    }
}
