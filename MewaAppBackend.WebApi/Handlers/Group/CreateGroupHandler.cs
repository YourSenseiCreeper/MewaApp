using AutoMapper;
using MediatR;
using MewaAppBackend.Business.EntityFramework;
using MewaAppBackend.Business.Repository;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi.Commands.Group;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Handlers.Group
{
    public class CreateGroupHandler : IRequestHandler<CreateGroupCommand, IActionResult>
    {
        private readonly IRepository<Model.Model.Link> linkRepository;
        private readonly IRepository<Model.Model.User> userRepository;
        private readonly IRepository<Model.Model.Tag> tagRepository;
        protected readonly IMapper _mapper;
        private readonly Context _context;
        public CreateGroupHandler(IUnitOfWork unitOfWork, IMapper mapper, Context context)
        {
            linkRepository = unitOfWork.Repository<Model.Model.Link>();
            userRepository = unitOfWork.Repository<Model.Model.User>();
            tagRepository = unitOfWork.Repository<Model.Model.Tag>();
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var links = linkRepository.ObjectSet.Where(l => request.Links.Contains(l.Id)).ToList();
            var tags = tagRepository.ObjectSet.Where(t => request.Tags.Contains(t.Id)).ToList();

            var group = new Model.Model.Group
            {
                Name = request.Name,
                IsFolder = request.IsFolder,
                Links = links,
                Tags = tags,
            };

            var newGroup = _context.Group.Add(group).Entity;
            var resultUsers = new List<GroupUser>();
            foreach (var user in request.Users)
            {
                resultUsers.Add(new GroupUser { UserId = user.UserId, GroupId = newGroup.Id });
            }
            newGroup.Users = resultUsers;

            _context.SaveChanges();

            return new OkResult();
        }
    }
}
