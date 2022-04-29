using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries.Link;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class GetUserLinksQueryHandler : IRequestHandler<GetUserLinksQuery, IEnumerable<LinkDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetUserLinksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LinkDto>> Handle(GetUserLinksQuery request, CancellationToken cancellationToken)
        {
            var results = _unitOfWork.Repository<Model.Model.Link>()
                .GetAll()
                .Where(l => l.OwnerId == request.UserId)
                .Include(l => l.Thumbnail)
                .Include(l => l.Tags)
                .Include(l => l.Groups)
                .AsNoTracking()
                .ToList();

            var dto = _mapper.Map<IEnumerable<LinkDto>>(results);

            return dto;
        }
    }
}