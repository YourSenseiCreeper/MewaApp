using AutoMapper;
using MewaAppBackend.Model.Dtos.Link;
using MewaAppBackend.Model.Dtos.User;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.WebApi.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entity, Link>();
            CreateMap<AddUserToSomething, User>();
            CreateMap<Entity, Tag>();
            CreateMap<Tag, TagDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<Link, LinkDto>().AfterMap((link, dto) => dto.ThumbnailContent = link.Thumbnail?.Content);
        }
    }
}
