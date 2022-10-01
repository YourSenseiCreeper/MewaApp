using MewaAppBackend.Business.Repository;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Business.Business
{
    public class LinkBusiness : ILinkBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRepository<Link> _linkRepository;

        public LinkBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _linkRepository = _unitOfWork.Repository<Link>();
        }

        public Link CreateLink(string name, string url, DateTime expiryDate, string? description)
        {
            var newLink = new Link()
            {
                Name = name,
                Url = url,
                Description = description,
                ExpiryDate = expiryDate,
            };
            _linkRepository.Add(newLink);

            return newLink;
        }
    }
}
