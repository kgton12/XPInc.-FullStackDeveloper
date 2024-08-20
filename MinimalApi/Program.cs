using Microsoft.EntityFrameworkCore;
using MinimalApi.Common.Extensions;
using MinimalApi.Domain.Interface;
using MinimalApi.Domain.Services;
using MinimalApi.Infrastructure.DB;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IServiceAdministrator, ServiceAdministrator>();
builder.Services.AddScoped<IServiceVehicle, ServiceVehicle>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

#endregion

#region App
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapEndpoints();

app.Run();
#endregion

// TODO: Get para teronar os veiculos;