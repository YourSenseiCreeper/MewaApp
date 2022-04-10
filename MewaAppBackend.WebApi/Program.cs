using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi;
using MewaAppBackend.WebApi.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MewaApp")));
builder.Services.AddDefaultIdentity<User>(
    x => {
        x.Password.RequireDigit = false;
        x.Password.RequiredLength = 2;
        x.Password.RequireUppercase = false;
        x.Password.RequireLowercase = false;
        x.Password.RequireNonAlphanumeric = false;
        x.Password.RequiredUniqueChars = 0;
        x.Lockout.AllowedForNewUsers = true;
        x.Lockout.MaxFailedAccessAttempts = 5;
        x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
        x.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<Context>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MewaApp", Version = "v1" });
});
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IUnitOfWork, GenericUnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.RunSeeder(args);
}
app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "MewaAppFront";

    spa.UseAngularCliServer(npmScript: "start");
    
});

app.Run();
