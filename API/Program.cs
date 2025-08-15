using Application.Interfaces;
using Authorization.Application.Services;
using Authorization.Infrastructure.DataDB;
using Authorization.Infrastructure.DataDB.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IHandlerLogin, HandlerLogin>();
builder.Services.AddScoped<IHandlerRegistration, HandlerRegistration>();
builder.Services.AddScoped<IHandlerUpdateEmail, HandlerUpdateEmail>();
builder.Services.AddScoped<IHandlerUpdateLogin, HandlerUpdateLogin>();
builder.Services.AddScoped<IHandlerUpdateName, HandlerUpdateName>();
builder.Services.AddScoped<IHandlerUpdatePassword, HandlerUpdatePassword>();

builder.Services.AddScoped<IUserDomainActions, UserRepository>();



builder.Services.AddDbContext<AuthorizationDbContext>(
    options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("AuthDBContext"));
    }
    );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
