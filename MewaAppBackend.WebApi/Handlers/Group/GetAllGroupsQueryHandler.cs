using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries.Group;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, IEnumerable<GroupDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupDto>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            var data = _unitOfWork.Repository<Model.Model.Group>()
                .GetAll()
                .Include(g => g.Links)
                .Include(g => g.Tags)
                .Include(g => g.Users)
                .AsNoTracking()
                .ToList();

            var dto = _mapper.Map<IEnumerable<GroupDto>>(data);
            return dto;
        }
    }
}
