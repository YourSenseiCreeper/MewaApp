using MewaAppBackend.Business.UnitOfWork;

namespace MewaAppBackend.Business.Business
{
    public class BusinessFactory : IBusinessFactory
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusinessFactory(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IGroupBusiness GroupBusiness
        {
            get
            {
                return new GroupBusiness(_unitOfWork);
            }
        }

        public IUserBusiness UserBusiness
        {
            get
            {
                return new UserBusiness(_unitOfWork);
            }
        }

        public ILinkBusiness LinkBusiness
        {
            get
            {
                return new LinkBusiness(_unitOfWork);
            }
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
