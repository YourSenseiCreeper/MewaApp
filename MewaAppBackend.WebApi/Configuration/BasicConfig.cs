using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MewaAppBackend.WebApi.Configuration
{
    public static class BasicConfig
    {
        public static void Handle(WebApplicationBuilder builder) 
        {
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "MewaAppFront/dist";
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(new string[]
                    {
             "https://localhost:7097",
             "http://localhost:7097",
             "http://localhost:5097",
             "https://localhost:5097",
             "http://localhost:4200",
             "https://localhost:4200",
                    })
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host) => true));
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Database
            builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MewaApp")));

            builder.Services.AddIdentity<Model.Model.User, IdentityRole>()
            .AddEntityFrameworkStores<Context>()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication()
            .AddJwtBearer(config =>
            {
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                };
            });
        }
    }
}
