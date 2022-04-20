using MediatR;
using MewaAppBackend.WebApi.Handlers.Tag;

namespace MewaAppBackend.WebApi.Commands.Tag
{
    public class AddTagCommand : IRequest<AddTagCommandResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
