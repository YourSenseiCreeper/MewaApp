using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Queries.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class GetDetailGroupQueryHandler : IRequestHandler<GetDetailGroupQuery, Model.Model.Group>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetDetailGroupQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        Task<Model.Model.Group> IRequestHandler<GetDetailGroupQuery, Model.Model.Group>.Handle(GetDetailGroupQuery request, CancellationToken cancellationToken)
        {
            var group = unitOfWork.Repository<Model.Model.Group>().GetDetail(g => g.Id == request.Id);
            return Task.FromResult(group);
        }
    }
}
