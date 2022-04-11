using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi.Queries;

namespace MewaAppBackend.WebApi.Handlers.Link
{
    public class GetLinkByIdQueryHandler : IRequestHandler<GetLinkByIdQuery, Model.Model.Link>
    {
        private IUnitOfWork _unitOfWork;
        public GetLinkByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Model.Model.Link> Handle(GetLinkByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.Repository<Model.Model.Link>().GetDetail(l => l.Id == request.Id);
            return Task.FromResult(result);
        }
    }
}
