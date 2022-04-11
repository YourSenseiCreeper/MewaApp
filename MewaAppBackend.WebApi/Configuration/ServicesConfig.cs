using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Services.User;
using MewaAppBackend.WebApi.UnitOfWork;
using System.Reflection;

namespace MewaAppBackend.WebApi.Configuration
{
    public static class ServicesConfig
    {
        public static void Handle(WebApplicationBuilder builder) 
        {
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            builder.Services.AddTransient<IUnitOfWork, GenericUnitOfWork>();
            builder.Services.AddScoped<IUserCreationService, UserCreationService>();
        }
    }
}
