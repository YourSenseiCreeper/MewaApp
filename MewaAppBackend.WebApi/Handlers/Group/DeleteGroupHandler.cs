using AutoMapper;
using MediatR;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.WebApi.Commands.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand, IActionResult>
    {
        private readonly IMapper _mapper;
        private readonly IBusinessFactory _businessFactory;
        public DeleteGroupHandler(IBusinessFactory businessFactory, IMapper mapper)
        {
            _businessFactory = businessFactory;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = _businessFactory.GroupBusiness.GetById(request.Id);
            if (group == null)
                return new BadRequestObjectResult($"Group with id {request.Id} dose not exist");

            await _businessFactory.GroupBusiness.DeleteGroup(request.Id);
            _businessFactory.SaveChanges();
            return new OkResult();
        }
    }
}
