using MediatR;
using MewaAppBackend.Model.Dtos.Group;

namespace MewaAppBackend.WebApi.Queries.Group
{
    public class GetDetailGroupQuery : IRequest<GroupDto>
    {
        public int Id { get; set; }
    }
}
