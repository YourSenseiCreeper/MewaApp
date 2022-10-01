using MewaAppBackend.Model.Interfaces;

namespace MewaAppBackend.Business.Business
{
    public class BusinessFactory : IBusinessFactory
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusinessFactory(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public GroupBusiness GroupBusiness
        {
            get
            {
                return new GroupBusiness(_unitOfWork);
            }
        }

        public UserBusiness UserBusiness
        {
            get
            {
                return new UserBusiness(_unitOfWork);
            }
        }

        public void SaveChanges() 
        {
            _unitOfWork.SaveChanges();
        }
    }
}
