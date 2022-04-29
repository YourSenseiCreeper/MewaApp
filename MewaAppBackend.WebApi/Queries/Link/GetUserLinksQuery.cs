using MediatR;
using MewaAppBackend.Model.Dtos.Link;

namespace MewaAppBackend.WebApi.Queries.Link
{
    public class GetUserLinksQuery : IRequest<IEnumerable<LinkDto>>
    {
        public string UserId { get; set; }
    }
}
