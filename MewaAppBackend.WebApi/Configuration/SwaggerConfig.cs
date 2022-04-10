using Microsoft.OpenApi.Models;

namespace MewaAppBackend.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void Handle(WebApplicationBuilder builder) 
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MewaApp", Version = "v1" });
            });
        }
    }
}
