using MediatR;
using MewaAppBackend.Model.Dtos.Tag;

namespace MewaAppBackend.WebApi.Queries.Tag
{
    public class GetTagByIdQuery : IRequest<TagDto>
    {
        public int Id { get; set; }
    }
}
