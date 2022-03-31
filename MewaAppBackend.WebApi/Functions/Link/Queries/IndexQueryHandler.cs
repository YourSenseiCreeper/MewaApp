using MediatR;
using MewaAppBackend.WebApi.Queries.List;
using MewaAppBackend.WebApi.UnitOfWork;

namespace MewaAppBackend.WebApi.Functions.Link.Queries
{
    public class IndexQueryHandler : IRequestHandler<IndexQuery, List<Model.Model.Link>>
    {
        private GenericUnitOfWork uow = null;
        public IndexQueryHandler(GenericUnitOfWork _uow)
        {
            this.uow = _uow;
        }
        Task<List<Model.Model.Link>> IRequestHandler<IndexQuery, List<Model.Model.Link>>.Handle(IndexQuery request, CancellationToken cancellationToken)
        {
            var links = uow.Repository<Model.Model.Link>().GetAll().ToList();
            return Task.FromResult(links);
        }
    }
}
