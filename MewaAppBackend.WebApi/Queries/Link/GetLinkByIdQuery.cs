using MediatR;
using MewaAppBackend.Model.Dtos.Link;

namespace MewaAppBackend.WebApi.Queries
{
    public record GetLinkByIdQuery : IRequest<LinkDto>
    {
        public int Id { get; set; }
    }
  
}
