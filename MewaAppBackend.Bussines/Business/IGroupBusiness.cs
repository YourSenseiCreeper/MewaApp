using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Business.Business
{
    public interface IGroupBusiness
    {
        Group CreatePersonalGroup(User owner);
        Group AddOwner(Group group, User owner);
    }
}