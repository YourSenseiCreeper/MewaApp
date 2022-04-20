using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries.Group;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class GetDetailGroupQueryHandler : IRequestHandler<GetDetailGroupQuery, GroupDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetDetailGroupQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GroupDto> Handle(GetDetailGroupQuery request, CancellationToken cancellationToken)
        {
            var group = _unitOfWork.Repository<Model.Model.Group>()
                .GetAll()
                .Where(g => g.Id == request.Id)
                .Include(g => g.Links)
                .Include(g => g.Tags)
                .Include(g => g.Users)
                .AsNoTracking()
                .FirstOrDefault();

            var dto = _mapper.Map<GroupDto>(group);

            return dto;
        }
    }
}
