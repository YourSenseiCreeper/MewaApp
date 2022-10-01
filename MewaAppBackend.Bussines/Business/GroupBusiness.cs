using MewaAppBackend.Business.Repository;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Enum;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Business.Business
{
    public class GroupBusiness : IGroupBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRepository<Group> _groupRepository;
        private IRepository<GroupUser> _groupUserRepository;

        public GroupBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _groupRepository = _unitOfWork.Repository<Group>();
            _groupUserRepository = _unitOfWork.Repository<GroupUser>();
        }

        public Group CreatePersonalGroup(User owner)
        {
            var newGroup = GetPersonalGroupObject();
            _groupRepository.Add(newGroup);
            return newGroup;
        }

        private Group GetPersonalGroupObject()
        {
            return new Group()
            {
                Name = "DASHBOARD",
                IsPersonal = true,
                IsFolder = true,
            };
        }

        public Group AddOwner(Group group, User owner)
        {
            var newGroupUser = new GroupUser()
            {
                GroupId = group.Id,
                UserId = owner.Id,
                Privilage = Privilage.Owner
            };
            _groupUserRepository.Add(newGroupUser);

            group.Users = new List<GroupUser>() { newGroupUser };
            return group;
        }

        public void AddLinkToGroup(Group group, Link link)
        {
            var links = new List<Link>(group.Links);
            links.Add(link);

            link.Group = group;
            group.Links = links;

            _groupRepository.Edit(group);
        }

        public Group GetById(int id) 
        {
            return _groupRepository.GetDetail(x => x.Id == id);
        }
    }
}
