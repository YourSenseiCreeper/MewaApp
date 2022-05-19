using MediatR;
using MewaAppBackend.Model.Dtos.User;

namespace MewaAppBackend.WebApi.Commands.User
{
    public class GetAllUsersCommand : IRequest<IEnumerable<UserDto>>
    {
    }
}
