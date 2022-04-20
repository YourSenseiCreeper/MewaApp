using MediatR;
using MewaAppBackend.Model.Dtos.Tag;

namespace MewaAppBackend.WebApi.Queries.Tag
{
    public class GetAllTagsQuery : IRequest<IEnumerable<TagDto>>
    {
    }
}
