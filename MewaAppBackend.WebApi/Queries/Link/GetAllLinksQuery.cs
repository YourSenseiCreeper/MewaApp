using MediatR;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.WebApi.Queries
{
    public record GetAllLinksQuery : IRequest<IEnumerable<Link>>
    {
    }
}
