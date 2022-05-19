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
                .Where(g => g.Users.Any(u => u.Id == userFromName.Id || )) // user is owner or is a member of group
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var linksWithoutGroup = await _unitOfWork.Repository<Model.Model.Link>()
                .GetAllIncluding(l => l.Groups)
                .Where(l => !l.Groups.Any() && l.OwnerId == userFromName.Id)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var linksSharedWithUser = await _unitOfWork.Repository<Model.Model.Link>()
                .GetAllIncluding(l => l.Groups)
                .Where(l => l.Groups.Any(u => u.Users.Any(u => u.UserId == userFromName.Id)))
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var resultGroups = new List<Model.Model.Group>();
            var resultLinks = new List<Model.Model.Link>();

            if (isCurrentUser)
            {
                resultGroups = groups.Where(g => g.Tags.Any(t => t.Name.StartsWith("#"))).ToList();
                resultLinks = linksWithoutGroup;
            } else
            {
                resultGroups = groups.Where(g => g.IsPublic && g.Tags.Any(t => t.Name.StartsWith("#"))).ToList();
                resultLinks = linksWithoutGroup.Where(l => l.IsPublic).ToList();
            }

            var dto = new DashboardDto
            {
                Groups = _mapper.Map<IEnumerable<MicroGroupDto>>(resultGroups),
                Links = _mapper.Map<IEnumerable<LinkDto>>(resultLinks)
            };

            return dto;
        }
    }
}
