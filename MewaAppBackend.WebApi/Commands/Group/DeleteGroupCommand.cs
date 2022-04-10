using MediatR;

namespace MewaAppBackend.WebApi.Commands.Group
{
    public class DeleteGroupCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
