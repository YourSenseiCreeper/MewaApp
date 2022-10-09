using AutoMapper;
using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Model.Dtos;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.WebApi.Commands.Link;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class AddLinkToGroupHandler : IRequestHandler<AddLinkToGroupCommand, ActionResult<MewaElementDto>>
    {
        private readonly IBusinessFactory _businessFactory;
        private readonly IMapper _mapper;

        public AddLinkToGroupHandler(IBusinessFactory businessFactory, IMapper mapper)
        {
            _businessFactory = businessFactory;
            _mapper = mapper;
        }

        public async Task<ActionResult<MewaElementDto>> Handle(AddLinkToGroupCommand request, CancellationToken cancellationToken)
        {
            // Later in this handler should be tag creation and assigment to link
            var newLink = _businessFactory.LinkBusiness.CreateLink(request.Name, request.Url, request.ExpiryDate, request.Description);

            var group = _businessFactory.GroupBusiness.GetById(request.GroupId);
            if (group == null)
                return new BadRequestObjectResult($"Group with id: {request.GroupId} dose not exist");

            _businessFactory.GroupBusiness.AddLinkToGroup(group, newLink);
            _businessFactory.SaveChanges();

            return new OkObjectResult(_mapper.Map<MewaElementDto>(newLink));
        }
    }
}
