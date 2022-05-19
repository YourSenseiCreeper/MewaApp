using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Dtos.Dashboard;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries.Dashboard;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.WebApi.Handlers.Dashboard
{
    public class GetDashboardByUserQueryHandler : IRequestHandler<GetDashboardByUserQuery, DashboardDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetDashboardByUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DashboardDto> Handle(GetDashboardByUserQuery request, CancellationToken cancellationToken)
        {
            var userFromName = _unitOfWork.Repository<Model.Model.User>().GetDetail(u => u.UserName == request.Username);
            var isCurrentUser = userFromName.Id == request.UserId;

            // all groups
            var groups = await _unitOfWork.Repository<Model.Model.Group>()
                .GetAllIncluding(g => g.Tags, g => g.Users)
                .Where(g => g.Users.Any(u => u.UserId == userFromName.Id)) // user is owner or is a member of group
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var linksWithoutGroup = await _unitOfWork.Repository<Model.Model.Link>()
                .GetAllIncluding(l => l.Groups)
                .Where(l => !l.Groups.Any() && l.OwnerId == userFromName.Id)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var groupsSharedWithUser = await _unitOfWork.Repository<Model.Model.Group>()
                .GetAllIncluding(l => l.Users, l => l.Tags)
                .Where(g => g.Users.Any(u => u.UserId == userFromName.Id))
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var resultGroups = new List<MicroGroupDto>();
            var resultLinks = new List<Model.Model.Link>();

            if (isCurrentUser)
            {
                resultGroups = groups.Select(g => new MicroGroupDto { Id = g.Id, Name = g.Name, IsShared = false}).ToList();
                resultGroups.AddRange(groupsSharedWithUser.Select(g => new MicroGroupDto { Id = g.Id, Name = g.Name, IsShared = true }).ToList());
                resultLinks = linksWithoutGroup;
            } else
            {
                resultGroups = groups.Where(g => g.IsPublic).Select(g => new MicroGroupDto { Id = g.Id, Name = g.Name, IsShared = false }).ToList();
                resultLinks = linksWithoutGroup.Where(l => l.IsPublic).ToList();
            }

            var dto = new DashboardDto
            {
                Groups = resultGroups,
                Links = _mapper.Map<IEnumerable<LinkDto>>(resultLinks)
            };

            return dto;
        }
    }
}
