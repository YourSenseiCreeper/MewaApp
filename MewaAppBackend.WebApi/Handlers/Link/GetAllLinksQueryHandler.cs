using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class GetAllLinksQueryHandler : IRequestHandler<GetAllLinksQuery, IEnumerable<LinkDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllLinksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
                .Include(l => l.Groups)
                .AsNoTracking()
                .ToList();

            var dto = _mapper.Map<IEnumerable<LinkDto>>(results);

            return dto;
        }
    }
}
