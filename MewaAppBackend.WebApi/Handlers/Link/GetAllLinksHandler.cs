using AutoMapper;
using MediatR;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.WebApi.Queries;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class GetAllLinksHandler : IRequestHandler<GetAllLinksQuery, IEnumerable<LinkDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllLinksHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LinkDto>> Handle(GetAllLinksQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.Repository<Model.Model.Link>()
                .GetAll()
                //.Include(l => l.Thumbnail)
                .Include(l => l.Tags)
                .AsNoTracking()
                .ToList();

            var dto = _mapper.Map<IEnumerable<LinkDto>>(results);

            return dto;
        }
    }
}
