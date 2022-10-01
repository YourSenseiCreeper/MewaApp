using AutoMapper;
using MediatR;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Dtos.Tag;
using MewaAppBackend.WebApi.Queries.Tag;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Tag
{
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<TagDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTagsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Model.Model.Tag>();
            var data = repository.GetAll()
                .Where(t => t.Name.ToLower().Contains(request.TagQuery))
                .Take(request.Amount)
                .AsNoTracking().ToList();
            return _mapper.Map<IEnumerable<TagDto>>(data);
        }
    }
}
