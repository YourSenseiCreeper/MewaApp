using AutoMapper;
using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Model.Dtos;
using MewaAppBackend.WebApi.Commands.Link;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class EditLinkHandler : IRequestHandler<EditLinkCommand, ActionResult<MewaElementDto>>
    {
        private readonly IBusinessFactory _businessFactory;
        private readonly IMapper _mapper;

        public EditLinkHandler(IBusinessFactory businessFactory, IMapper mapper)
        {
            _businessFactory = businessFactory;
            _mapper = mapper;
        }

        public async Task<ActionResult<MewaElementDto>> Handle(EditLinkCommand request, CancellationToken cancellationToken)
        {

            var entity = _businessFactory.LinkBusiness.GetLinkById(request.Id);
            if (entity == null)
                return new BadRequestObjectResult($"Link with id: {request.Id} dose not exist");


            var newGroup = _businessFactory.GroupBusiness.GetGroupById(request.GroupId);
            if (newGroup == null)
                return new BadRequestObjectResult($"Group with id: {request.GroupId} dose not exist");

            var edditEdentity = MapToLink(entity, request, newGroup);

            _businessFactory.LinkBusiness.UpdateLink(edditEdentity);
            _businessFactory.SaveChanges();

            return new OkObjectResult(_mapper.Map<MewaElementDto>(edditEdentity));
        }

        private Model.Model.Link MapToLink(Model.Model.Link entity, EditLinkCommand request, Model.Model.Group group)
        {
            entity.Url = request.Url;
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Group = group;

            return entity;
        }
    }
}
