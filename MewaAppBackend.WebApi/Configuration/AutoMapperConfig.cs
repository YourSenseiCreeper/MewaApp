using AutoMapper;
using MewaAppBackend.Model.Model;

namespace MewaAppBackend.WebApi.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entity, Link>();
            CreateMap<Entity, User>();
            CreateMap<Entity, Tag>();
        }
    }
}
