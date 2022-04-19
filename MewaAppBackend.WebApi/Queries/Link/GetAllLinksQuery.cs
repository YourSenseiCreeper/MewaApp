using MediatR;
using MewaAppBackend.Model.Dtos.Link;

namespace MewaAppBackend.WebApi.Queries
{
    public record GetAllLinksQuery : IRequest<IEnumerable<LinkDto>>
    {
    }
}
