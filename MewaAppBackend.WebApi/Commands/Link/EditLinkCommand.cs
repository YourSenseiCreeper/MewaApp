using MediatR;
using MewaAppBackend.WebApi.Handlers.Link;

namespace MewaAppBackend.WebApi.Commands.Link
{
    public class EditLinkCommand : IRequest<EditLinkCommandResult>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string OwnerId { get; set; }
        public int? ThumbnailId { get; set; }
        public IEnumerable<int> Tags { get; set; }
        public IEnumerable<int> Groups { get; set; }
    }
}
