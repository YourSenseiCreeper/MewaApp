using MewaAppBackend.Business.Repository;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Business.Business
{
    public class TagBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRepository<Tag> _tagRepository;

        public TagBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _tagRepository = _unitOfWork.Repository<Tag>();
        }

        public Tag CreateTag(User user, string name, string? description)
        {
            var newTag = new Tag()
            {
                User = user,
                Name = name,
                Description = description
            };
            _tagRepository.Add(newTag);
            return newTag;
        }
    }
}
