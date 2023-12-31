﻿using MewaAppBackend.Business.Repository;
using MewaAppBackend.Business.UnitOfWork;
using MewaAppBackend.Model.Enum;
using MewaAppBackend.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace MewaAppBackend.Business.Business
{
    public class GroupBusiness : IGroupBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRepository<Group> _groupRepository;
        private IRepository<GroupUser> _groupUserRepository;

        public GroupBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _groupRepository = _unitOfWork.Repository<Group>();
            _groupUserRepository = _unitOfWork.Repository<GroupUser>();
        }

        public Group CreatePersonalGroup(User owner)
        {
            var newGroup = GetGroupObject("DASHBOARD", true);
            _groupRepository.Add(newGroup);
            return newGroup;
        }

        public Group CreateGroup(string name)
        {
            var newGroup = GetGroupObject(name, false);
            _groupRepository.Add(newGroup);
            return newGroup;
        }

        private Group GetGroupObject(string name, bool isPersonal)
        {
            return new Group()
            {
                Name = name,
                IsPersonal = isPersonal,
                GroupLvl = 1
            };
        }

        public Group AddOwner(Group group, User owner)
        {
            var newGroupUser = new GroupUser()
            {
                GroupId = group.Id,
                UserId = owner.Id,
                Privilage = Privilage.Owner
            };
            _groupUserRepository.Add(newGroupUser);

            group.Users = new List<GroupUser>() { newGroupUser };
            return group;
        }

        public void AddLinkToGroup(Group group, Link link)
        {
            var links = new List<Link>(group.Links);
            links.Add(link);

            link.Group = group;
            group.Links = links;

            _groupRepository.Edit(group);
        }

        public void AddGroupToGroup(Group parentGroup, Group group)
        {
            var newGroupUser = new GroupUser()
            {
                GroupId = group.Id,
                UserId = parentGroup.Users.First(x => x.IsOwner).UserId,
                Privilage = Privilage.Owner
            };
            _groupUserRepository.Add(newGroupUser);

            group.ParentGroupId = parentGroup.Id;
            group.GroupLvl = parentGroup.GroupLvl + 1;
            _groupRepository.Edit(group);
        }

        public Group GetById(int id) 
        {
            return _groupRepository.GetDetail(x => x.Id == id);
        }

        public Group GetFullGroupById(int id)
        {
            return _groupRepository
                .ObjectSet
                .Where(x => x.Id == id)
                .Include(x => x.ParentGroup)
                .Include(x => x.Users)
                .Include(x => x.Links)
                .FirstOrDefault();
        }

        public Group GetDashboardByUserId(string userId) 
        {
            return _groupRepository
                .ObjectSet
                .Where(x => x.Users.Any(q => q.UserId == userId) && x.IsPersonal)
                .Include(x => x.ParentGroup)
                .Include(x => x.Users)
                .Include(x => x.Links)
                .FirstOrDefault();
        }

        public Group GetGroupById(int id)
        {
            return _groupRepository
                .ObjectSet
                .Where(x => x.Id == id)
                .Include(x => x.ParentGroup)
                .Include(x => x.Users)
                .Include(x => x.Links)
                .FirstOrDefault();
        }

        public IEnumerable<Group> GetChildrenGroups(int groupId)
        {
            return _groupRepository
                .ObjectSet.Where(x => x.ParentGroupId == groupId);
        }

        public async Task DeleteGroup(int groupId) 
        {
            var group = await _groupRepository
                .ObjectSet
                .Where(x => x.Id == groupId)
                .FirstOrDefaultAsync();

            RecursiveDelete(group);
        }

        private void RecursiveDelete(Group parent)
        {
            var childrens = GetChildrenGroups(parent.Id).ToList();
            if (childrens.Count != 0)
            {
                foreach (var child in childrens)
                {
                    RecursiveDelete(child);
                }
            }

            _groupRepository.Delete(parent);
        }
    }
}
