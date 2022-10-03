﻿using MediatR;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.WebApi.Commands.Link;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class DeleteLinkHandler : IRequestHandler<DeleteLinkCommand, IActionResult>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteLinkHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Handle(DeleteLinkCommand request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.Repository<Model.Model.Link>();
            var entity = repository.GetAllIncluding(l => l.Tags).FirstOrDefault(l => l.Id == request.Id);

            if (entity == null)
                return new BadRequestObjectResult($"Link with id {request.Id} dose not exist");

            repository.Delete(entity);
            unitOfWork.SaveChanges();

            return new OkResult();
        }
    }
}