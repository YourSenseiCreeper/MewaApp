using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.Services.GroupsAndLinks
{
    public interface IGetGroupDtoService
    {
        GroupDto GetGroup(Group group);
    }
}