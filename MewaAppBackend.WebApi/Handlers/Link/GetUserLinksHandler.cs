using AutoMapper;
using MediatR;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.WebApi.Queries.Link;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class GetUserLinksHandler : IRequestHandler<GetUserLinksQuery, IEnumerable<LinkDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetUserLinksHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LinkDto>> Handle(GetUserLinksQuery request, CancellationToken cancellationToken)
        {
            var results = new List<Model.Model.Link>();
            if (request.UserId != null)
            {
                results = _unitOfWork.Repository<Model.Model.Link>()
                .GetAll()
                .Include(l => l.Thumbnail)
                .Include(l => l.Tags)
                .AsNoTracking()
                .ToList();
            }
            else
            {
                results = _unitOfWork.Repository<Model.Model.Link>()
                .GetAll()
                .Include(l => l.Thumbnail)
                .Include(l => l.Tags)
                .AsNoTracking()
                .ToList();

            }

            if (string.IsNullOrEmpty(request.UserId))
                results = results.ToList();

            var dto = _mapper.Map<IEnumerable<LinkDto>>(results);

            return dto;
        }
    }
}