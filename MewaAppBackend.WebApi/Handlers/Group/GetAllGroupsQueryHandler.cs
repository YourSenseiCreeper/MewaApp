using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries.Group;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, IEnumerable<Model.Model.Group>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllGroupsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Model.Model.Group>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            return unitOfWork.Repository<Model.Model.Group>().GetAll();
        }
    }
}
