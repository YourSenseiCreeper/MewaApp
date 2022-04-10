using MediatR;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.WebApi.Queries.Group
{
    public class GetDetailGroupQuery : IRequest<Model.Model.Group>
    {
        public int Id { get; set; }
    }
}
