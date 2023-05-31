using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceApi.Models;
using ServiceApi.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddControllers();
var MiCors = "MiCors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors, builder => { builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod(); }); //WithOrigins("*"); });

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MiCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
