using MewaAppBackend.Model.Model;
using MewaAppBackend.WebApi;
using MewaAppBackend.WebApi.Configuration;
using Microsoft.AspNetCore.SpaServices.AngularCli;

var builder = WebApplication.CreateBuilder(args);

BasicConfig.Handle(builder);
ServicesConfig.Handle(builder);
SwaggerConfig.Handle(builder);

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
