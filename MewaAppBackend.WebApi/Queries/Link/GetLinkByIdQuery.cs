using MediatR;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.WebApi.Queries
{
    public record GetLinkByIdQuery : IRequest<Link>
    {
        public int Id { get; set; }
    }
  
}
