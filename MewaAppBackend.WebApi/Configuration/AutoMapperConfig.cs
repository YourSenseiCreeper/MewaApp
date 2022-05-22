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
            CreateMap<Entity, Tag>();
            CreateMap<Link, MicroLinkDto>();
            CreateMap<Tag, MicroTagDto>();
            CreateMap<Tag, TagDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<Group, MicroGroupDto>();
            CreateMap<Link, LinkDto>().AfterMap((link, dto) => dto.ThumbnailContent = link.Thumbnail?.Content);
            CreateMap<User, UserDto>();
            CreateMap<GroupUser, UserDto>()
                .ForMember(d => d.Id, options => options.MapFrom(t => t.User.Id))
                .ForMember(d => d.UserName, options => options.MapFrom(t => t.User.UserName))
                .ForMember(d => d.Email, options => options.MapFrom(t => t.User.Email));
            //CreateMap<UserDto, GroupUser>()
            //    .ForMember(d => d.User.Id, options => options.MapFrom(t => t.Id))
            //    .ForMember(d => d.User.UserName, options => options.MapFrom(t => t.UserName))
            //    .ForMember(d => d.User.Email, options => options.MapFrom(t => t.Email));
            CreateMap<GroupUser, MicroGroupDto>()
                .ForMember(d => d.Id, options => options.MapFrom(t => t.Group.Id))
                .ForMember(d => d.Name, options => options.MapFrom(t => t.Group.Name));
            //.ForMember(d => d.IsPublic, options => options.MapFrom(t => t.Group.IsPublic))
            CreateMap<GroupUser, GroupDto>()
                .ForMember(d => d.Id, options => options.MapFrom(t => t.Group.Id))
                .ForMember(d => d.Name, options => options.MapFrom(t => t.Group.Name));

        }
    }
}
