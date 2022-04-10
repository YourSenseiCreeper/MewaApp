using MediatR;
using MewaAppBackend.Model.Dtos.User;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.WebApi.Commands.Group
{
    public class CreateGroupCommand : IRequest
    {
        public string RedirectURL { get; set; }
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public IEnumerable<Entity> Links { get; set; }
        public IEnumerable<Entity> Tags { get; set; }
        public IEnumerable<AddUserToSomething> Users { get; set; }
    }
}
