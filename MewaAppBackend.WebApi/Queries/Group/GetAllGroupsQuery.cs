using MediatR;
using MewaAppBackend.Model.Dtos.Group;

namespace MewaAppBackend.WebApi.Queries.Group
{
    public class GetAllGroupsQuery : IRequest<IEnumerable<GroupDto>>
    {
    }
}
