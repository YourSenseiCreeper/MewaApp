using MediatR;
using MewaAppBackend.WebApi.Handlers.Group;

namespace MewaAppBackend.WebApi.Commands.Group
{
    public class DeleteGroupCommand : IRequest<DeleteGroupCommandResult>
    {
        public int Id { get; set; }
    }
}
