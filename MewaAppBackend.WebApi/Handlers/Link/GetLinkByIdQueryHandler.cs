using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class GetLinkByIdQueryHandler : IRequestHandler<GetLinkByIdQuery, LinkDto>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLinkByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<LinkDto> Handle(GetLinkByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.Repository<Model.Model.Link>()
                .GetAll()
                .Include(l => l.Thumbnail)
                .Include(l => l.Tags)
                .Where(l => l.Id == request.Id)
                .SingleOrDefault();

            var dto = _mapper.Map<LinkDto>(result);

            return Task.FromResult(dto);
        }
    }
}
