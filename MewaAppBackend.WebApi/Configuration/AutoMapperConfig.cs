using AutoMapper;
using MewaAppBackend.Model.Dtos.Group;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Dtos.Tag;
using MewaAppBackend.Model.Dtos.User;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.WebApi.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entity, Link>();
            CreateMap<Link, MicroLinkDto>();
            CreateMap<AddUserToSomething, User>();
            CreateMap<Entity, Tag>();
            CreateMap<Tag, MicroTagDto>();
            CreateMap<Tag, TagDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<Group, MicroGroupDto>();
            CreateMap<User, AddUserToSomething>();
            CreateMap<Link, LinkDto>().AfterMap((link, dto) => dto.ThumbnailContent = link.Thumbnail?.Content);
        }
    }
}
