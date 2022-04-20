using MediatR;
using MewaAppBackend.WebApi.Handlers.Tag;

namespace MewaAppBackend.WebApi.Commands.Tag
{
    public class DeleteTagCommand : IRequest<DeleteTagCommandResult>
    {
        public int Id { get; set; }
    }
}
