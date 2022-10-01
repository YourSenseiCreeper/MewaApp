using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Services.User;
using MewaAppBackend.WebApi.Commands.Link;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class AddLinkToGroupHandler : IRequestHandler<AddLinkToGroupCommand, IActionResult>
    {
        private readonly IBusinessFactory _businessFactory;

        public AddLinkToGroupHandler(IBusinessFactory businessFactory)
        {
            _businessFactory = businessFactory;
        }

        public async Task<IActionResult> Handle(AddLinkToGroupCommand request, CancellationToken cancellationToken)
        {
            var newLink = _businessFactory.LinkBusiness.CreateLink(request.Name, request.Url, request.ExpiryDate, request.Description);

            var group = _businessFactory.GroupBusiness.GetById(request.GroupId);
            if (group == null)
                return new BadRequestObjectResult($"Group with id: {request.GroupId} dose not exist");

            _businessFactory.GroupBusiness.AddLinkToGroup(group, newLink);
            _businessFactory.SaveChanges();
            return new OkResult();
        }
    }
}
