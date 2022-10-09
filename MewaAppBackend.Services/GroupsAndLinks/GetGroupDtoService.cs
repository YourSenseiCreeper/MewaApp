using AutoMapper;
using MewaAppBackend.Business.Business;
using MewaAppBackend.Model.Dtos;
using MewaAppBackend.Model.Dtos.Group;

namespace MewaAppBackend.Services.GroupsAndLinks
{
    public class GetGroupDtoService : IGetGroupDtoService
    {
        private readonly IBusinessFactory _businessFactory;
        private readonly IMapper _mapper;
        public GetGroupDtoService(IBusinessFactory businessFactory, IMapper mapper)
        {
            _businessFactory = businessFactory;
            _mapper = mapper;
        }

        public GroupDto GetGroup(Model.Model.Group group)
        {
            var chlidrenGroups = _businessFactory.GroupBusiness.GetChildrenGroups(group.Id);

            var allElements = new List<MewaElementDto>();

            var linksElements = _mapper.Map<IEnumerable<MewaElementDto>>(group.Links);
            allElements.AddRange(linksElements);

            var groupElements = _mapper.Map<IEnumerable<MewaElementDto>>(chlidrenGroups);
            allElements.AddRange(groupElements);

            var mapedGroup = _mapper.Map<GroupDto>(group);
            mapedGroup.Elements = allElements.OrderBy(x => !x.IsFolder);

            return mapedGroup;
        }
    }
}
