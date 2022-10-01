using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Business.Business
{
    public interface IGroupBusiness
    {
        void AddLinkToGroup(Group group, Link link);
        Group AddOwner(Group group, User owner);
        Group CreatePersonalGroup(User owner);
        Group GetById(int id);
    }
}