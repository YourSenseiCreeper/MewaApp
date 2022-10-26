using AutoMapper;
using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.WebApi.Commands.Link;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class DeleteLinkHandler : IRequestHandler<DeleteLinkCommand, IActionResult>
    {
        private readonly IBusinessFactory _businessFactory;
        private readonly IMapper _mapper;
        public DeleteLinkHandler(IBusinessFactory businessFactory, IMapper mapper)
        {
            _businessFactory = businessFactory;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
        {
            var link = _businessFactory.LinkBusiness.GetLinkById(request.Id);
            if (link == null)
                return new BadRequestObjectResult($"Link with id {request.Id} dose not exist");

            _businessFactory.LinkBusiness.DeleteLink(link);
            _businessFactory.SaveChanges();

            return new OkResult();
        }
    }
}
