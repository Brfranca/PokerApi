using AutoMapper;
using Poker.Domain.Models;
using Poker.Domain.Repositories;
using Poker.Infra.Config;
using Poker.Infra.Repositories;
using Poker.Service.DTOs.User;
using Poker.Service.Interfaces;
using Poker.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<Context>(ServiceLifetime.Scoped);

IMapper mapper = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserRequest, UserModel>();
    cfg.CreateMap<UserUpdateRequest, UserModel>();
    cfg.CreateMap<UserModel, UserResponse>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);

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

app.Run();
