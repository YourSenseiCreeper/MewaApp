using AutoMapper;
using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Model.Dtos;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.Services.GroupsAndLinks;
using MewaAppBackend.WebApi.Queries.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class GetDashboardByUserQueryHandler : IRequestHandler<GetDashboardByUserQuery, ActionResult<GroupDto>>
    {
        private readonly IBusinessFactory _businessFactory;
        private readonly IGetGroupDtoService _getGroupDtoService;

        public GetDashboardByUserQueryHandler(IBusinessFactory businessFactory, IGetGroupDtoService getGroupDtoService)
        {
            _businessFactory = businessFactory;
            _getGroupDtoService = getGroupDtoService;
        }

        public async Task<ActionResult<GroupDto>> Handle(GetDashboardByUserQuery request, CancellationToken cancellationToken)
        {
            var group = _businessFactory.GroupBusiness.GetDashboardByUserId(request.UserId);

            return new OkObjectResult(_getGroupDtoService.GetGroup(group));
        }
    }
}
