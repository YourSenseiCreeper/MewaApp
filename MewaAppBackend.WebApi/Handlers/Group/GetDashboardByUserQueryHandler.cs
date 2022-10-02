using AutoMapper;
using MediatR;
using MewaAppBackend.Business.Business;
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

            var mapedGroup = _mapper.Map<GroupDto>(group);
            mapedGroup.Groups = _mapper.Map<IEnumerable<MicroGroupDto>>(chlidrenGroups);
            return new OkObjectResult(mapedGroup);
        }
    }
}
