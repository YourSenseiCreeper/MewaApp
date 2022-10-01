using MediatR;
using MewaAppBackend.Model.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Commands.Group
{
    public class CreateGroupCommand : IRequest<IActionResult>
    {
        public string RedirectURL { get; set; }
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public IEnumerable<int> Links { get; set; }
        public IEnumerable<int> Tags { get; set; }
        public IEnumerable<GroupUserDto> Users { get; set; }
    }
}
