using MediatR;
using MewaAppBackend.Model.Dtos.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Group
{
    public class AddGroupToGroupCommand: IRequest<ActionResult<MicroGroupDto>>
    {
        public string Name { get; set; }
        public int ParentGroupId { get; set; }
    }
}
