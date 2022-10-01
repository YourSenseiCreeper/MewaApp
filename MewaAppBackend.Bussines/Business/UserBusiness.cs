using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Business.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRepository<User> _userRepository;

        public UserBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.Repository<User>();
        }

        public bool IsUserNameUsed(string userName)
        {
            return _userRepository.ObjectSet
                .Any(u => u.UserName.ToLower() == userName.ToLower());
        }

        public bool IsEmailUsed(string email)
        {
            return _userRepository.ObjectSet
                .Any(u => u.Email.ToLower() == email.ToLower());
        }
    }
}

