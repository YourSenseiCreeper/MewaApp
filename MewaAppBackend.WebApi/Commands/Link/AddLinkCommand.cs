using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Queries.Link
{
    public record AddLinkCommand : IRequest<IActionResult>
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string OwnerId { get; set; }
        public IEnumerable<int> Tags { get; set; }
        public IEnumerable<int> Groups { get; set; }
    }
}



