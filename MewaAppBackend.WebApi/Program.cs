using MewaAppBackend.WebApi;
using AutoMapper;
using MediatR;
using MewaAppBackend.Model.Interfaces;
using MewaAppBackend.WebApi;
using MewaAppBackend.WebApi.Configuration;
using MewaAppBackend.WebApi.UnitOfWork;
using Microsoft.AspNetCore.SpaServices.AngularCli;

var builder = WebApplication.CreateBuilder(args);

BasicConfig.Handle(builder);
ServicesConfig.Handle(builder);
SwaggerConfig.Handle(builder);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperConfig());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
