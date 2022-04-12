using MediatR;
using MewaAppBackend.WebApi.Handlers.Link;

namespace MewaAppBackend.WebApi.Commands.Link
{
    public class DeleteLinkCommand : IRequest<DeleteLinkCommandResult>
    {
        public int Id { get; set; }
    }
}
