using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalApi.Domain.DTOs;
using MinimalApi.Domain.Entity;
using MinimalApi.Domain.Interface;
using MinimalApi.Domain.Services;
using MinimalApi.Infrastructure.DB;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IServiceAdministrator, ServiceAdministrator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

// TODO: Criando Seed para cadastrar administrador padrao