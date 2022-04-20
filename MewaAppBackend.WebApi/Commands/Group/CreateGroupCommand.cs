using MediatR;

namespace MewaAppBackend.WebApi.Commands.Group
{
    public class CreateGroupCommand : IRequest
    {
        public string RedirectURL { get; set; }
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public IEnumerable<int> Links { get; set; }
        public IEnumerable<int> Tags { get; set; }
        public IEnumerable<string> Users { get; set; }
    }
}
