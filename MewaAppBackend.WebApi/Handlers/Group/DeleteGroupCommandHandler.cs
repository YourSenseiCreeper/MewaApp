﻿using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Commands.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, IActionResult>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Model.Model.Group> groupRepository;
        public DeleteGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            groupRepository = unitOfWork.Repository<Model.Model.Group>();
        }

        public async Task<IActionResult> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = groupRepository.GetDetail(g => g.Id == request.Id);
            if (group == null)
            {
                return new BadRequestObjectResult($"Group with id {request.Id} dose not exist");
            }
            groupRepository.Delete(group);
            unitOfWork.SaveChanges();

            return new OkResult();
        }
    }
}
