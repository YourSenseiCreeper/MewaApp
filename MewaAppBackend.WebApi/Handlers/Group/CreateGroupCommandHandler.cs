using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, IActionResult>
    {
        private readonly IRepository<Model.Model.Link> linkRepository;
        private readonly IRepository<Model.Model.User> userRepository;
        private readonly IRepository<Model.Model.Tag> tagRepository;
        protected readonly IMapper _mapper;
        private readonly Context _context;
        public CreateGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, Context context)
        {
            linkRepository = unitOfWork.Repository<Model.Model.Link>();
            userRepository = unitOfWork.Repository<Model.Model.User>();
            tagRepository = unitOfWork.Repository<Model.Model.Tag>();
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var links = linkRepository.GetAll().Where(l => request.Links.Contains(l.Id)).ToList();
            var tags = tagRepository.GetAll().Where(t => request.Tags.Contains(t.Id)).ToList();
            //var users = userRepository.GetAll().Where(u => request.Users.Contains(u.Id))
            //    .Select(u => new GroupUser { UserId = u.Id, GroupId = group.Id }).ToList();

            // sender is admin
            //var selectedUsers = new List<GroupUser>
            //{
            //    new GroupUser { User = null, Privilage = GroupPrivilage.Admin } // todo: attach current user
            //};
            //selectedUsers.AddRange(users.Select(u => new GroupUser { User = u, Privilage = GroupPrivilage.Reader }));

            var group = new Model.Model.Group
            {
                Name = request.Name,
                IsFolder = request.IsFolder,
                Links = links,
                Tags = tags,
            };

            var newGroup = _context.Group.Add(group).Entity;
            var resultUsers = new List<GroupUser>();
            foreach(var user in request.Users)
            {
                resultUsers.Add(new GroupUser { UserId = user.UserId, GroupId = newGroup.Id });
            }
            newGroup.Users = resultUsers;

            _context.SaveChanges();

            return new OkResult();
        }
    }
}
