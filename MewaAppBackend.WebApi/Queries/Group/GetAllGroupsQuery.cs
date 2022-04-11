using MediatR;

namespace MewaAppBackend.WebApi.Queries.Group
{
    public class GetAllGroupsQuery : IRequest<IEnumerable<Model.Model.Group>>
    {
    }
}
