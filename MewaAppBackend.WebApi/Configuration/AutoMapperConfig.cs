using AutoMapper;
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
        }
    }
}
