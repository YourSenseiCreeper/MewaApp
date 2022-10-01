using AutoMapper;
using MediatR;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.WebApi.Queries.Group;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class GetAllGroupsHandler : IRequestHandler<GetAllGroupsQuery, IEnumerable<GroupDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllGroupsHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
                .Include(g => g.Users).ThenInclude(g => g.User)
                .AsNoTracking()
                .ToList();

            var dto = _mapper.Map<IEnumerable<GroupDto>>(data);
            return dto;
        }
    }
}
