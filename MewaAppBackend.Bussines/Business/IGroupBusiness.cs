using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Business.Business
{
    public interface IGroupBusiness
    {
        void AddLinkToGroup(Group group, Link link);
        void AddGroupToGroup(Group parentGroup, Group group);
        Group AddOwner(Group group, User owner);
        Group CreatePersonalGroup(User owner);
        Group CreateGroup(string name);
        Group GetById(int id);
        Group GetFullGroupById(int id);
        Group GetDashboardByUserId(string userId);
        IEnumerable<Group> GetChildrenGroups(int groupId);
        Group GetGroupById(int id);
        Task DeleteGroup(int groupId);
    }
}