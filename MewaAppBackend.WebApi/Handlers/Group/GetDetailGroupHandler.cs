using AutoMapper;
using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.Services.GroupsAndLinks;
using MewaAppBackend.WebApi.Queries.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class GetDetailGroupHandler : IRequestHandler<GetDetailGroupQuery, ActionResult<GroupDto>>
    {
        private readonly IBusinessFactory _businessFactory;
        private readonly IGetGroupDtoService _getGroupDtoService;

        public GetDetailGroupHandler(IBusinessFactory businessFactory, IGetGroupDtoService getGroupDtoService)
        {
            _businessFactory = businessFactory;
            _getGroupDtoService = getGroupDtoService;
        }

        public async Task<ActionResult<GroupDto>> Handle(GetDetailGroupQuery request, CancellationToken cancellationToken)
        {
            var group = _businessFactory.GroupBusiness.GetGroupById(request.Id);
            if (group == null)
                return new BadRequestObjectResult($"No group with id {request.Id} found");

            return new OkObjectResult(_getGroupDtoService.GetGroup(group));
        }
    }
}
