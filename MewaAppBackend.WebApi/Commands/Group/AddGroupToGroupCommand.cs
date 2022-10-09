using MediatR;
using MewaAppBackend.Model.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Group
{
    public class AddGroupToGroupCommand : IRequest<ActionResult<MewaElementDto>>
    {
        public string Name { get; set; }
        public int ParentGroupId { get; set; }
    }
}
