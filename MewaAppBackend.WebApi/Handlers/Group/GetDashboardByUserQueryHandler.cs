using AutoMapper;
using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Model.Dtos;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.WebApi.Queries.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class GetDashboardByUserQueryHandler : IRequestHandler<GetDashboardByUserQuery, ActionResult<GroupDto>>
    {
        private readonly IBusinessFactory _businessFactory;
        private readonly IMapper _mapper;

        public GetDashboardByUserQueryHandler(IBusinessFactory businessFactory, IMapper mapper)
        {
            _businessFactory = businessFactory;
            _mapper = mapper;
        }

        public async Task<ActionResult<GroupDto>> Handle(GetDashboardByUserQuery request, CancellationToken cancellationToken)
        {
            var group = _businessFactory.GroupBusiness.GetDashboardByUserId(request.UserId);

            var chlidrenGroups = _businessFactory.GroupBusiness.GetChildrenGroups(group.Id);

            var allElements = new List<MewaElementDto>();

            var linksElements = _mapper.Map<IEnumerable<MewaElementDto>>(group.Links);
            allElements.AddRange(linksElements);

            var groupElements = _mapper.Map<IEnumerable<MewaElementDto>>(chlidrenGroups);
            allElements.AddRange(groupElements);

            var mapedGroup = _mapper.Map<GroupDto>(group);
            mapedGroup.Elements = allElements.OrderBy(x => !x.IsFolder);
            return new OkObjectResult(mapedGroup);
        }
    }
}
