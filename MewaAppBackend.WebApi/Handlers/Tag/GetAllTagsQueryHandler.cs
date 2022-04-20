using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Dtos.Tag;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries.Tag;

namespace MewaAppBackend.WebApi.Handlers.Tag
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<TagDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTagsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.Repository<Model.Model.Tag>();
            var data = repository.GetAll().ToList();
            var dto = _mapper.Map<IEnumerable<TagDto>>(data);
            return dto;
        }
    }
}
