using Academy.Application.Interfaces;
using Academy.Application.Services;
using Academy.Domain.Interfaces.Repository;
using Academy.Domain.Models;
using Academy.Infrastructure.Context;
using Academy.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton((serviceProvider) =>
{
    var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();
    optionsBuilder.UseSqlite(config.GetConnectionString("SampleConnection"));

    SampleContext context = new (optionsBuilder.Options);
    StudentRepository repo = new (context);
    StudentService service = new (repo);
    return service;
});

builder.Services.AddCors();
var MyAllowSpecificOrigins = "http://localhost:4200";

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
