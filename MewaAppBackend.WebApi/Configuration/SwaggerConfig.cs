using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MewaAppBackend.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void Handle(WebApplicationBuilder builder) 
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MewaApp API",
                    Description = "Application created by .Net Group Koszalin University of Technology",
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}
