using AutoMapper;
using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Model.Dtos;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.WebApi.Commands.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class AddGroupToGroupHandler : IRequestHandler<AddGroupToGroupCommand, ActionResult<MewaElementDto>>
    {
        private readonly IBusinessFactory _businessFactory;
        private readonly IMapper _mapper;

        public AddGroupToGroupHandler(IBusinessFactory businessFactory, IMapper mapper)
        {
            _businessFactory = businessFactory;
            _mapper = mapper;
        }

        public async Task<ActionResult<MewaElementDto>> Handle(AddGroupToGroupCommand request, CancellationToken cancellationToken)
        {
            var parentGroup = _businessFactory.GroupBusiness.GetFullGroupById(request.ParentGroupId);
            if (parentGroup == null)
                return new BadRequestObjectResult($"Group with id {request.ParentGroupId} dose not exist");

            if(parentGroup.GroupLvl > 2)
                return new BadRequestObjectResult($"If you want to have more files pls buy premium");

            var newGroup = _businessFactory.GroupBusiness.CreateGroup(request.Name);
            _businessFactory.SaveChanges();

            _businessFactory.GroupBusiness.AddGroupToGroup(parentGroup, newGroup);
            _businessFactory.SaveChanges();

            return new OkObjectResult(_mapper.Map<MewaElementDto>(newGroup));
        }
    }
}
