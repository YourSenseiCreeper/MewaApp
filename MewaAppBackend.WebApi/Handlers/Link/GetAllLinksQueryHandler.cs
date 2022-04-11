using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class GetAllLinksQueryHandler : IRequestHandler<GetAllLinksQuery, IEnumerable<Model.Model.Link>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllLinksQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Model.Model.Link>> Handle(GetAllLinksQuery request, CancellationToken cancellationToken)
        {
            return unitOfWork.Repository<Model.Model.Link>().GetAllIncluding(l => l.Tags);
        }
    }
}
