using MediatR;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class HasUserExistsCommand : IRequest<bool>
    {
        public string UserName { get; set; }
    }
}
