using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Poker.Domain.Models;
using Poker.Domain.Repositories;
using Poker.Infra.Config;
using Poker.Infra.Repositories;
using Poker.Service.DTOs.User;
using Poker.Service.Interfaces.Services;
using Poker.Service.Interfaces.UseCases;
using Poker.Service.Services;
using Poker.Service.UseCases;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthenticateUseCase, AuthenticateUseCase>();
builder.Services.AddScoped<IGenerateTokenUseCase, GenerateTokenUseCase>();
builder.Services.AddDbContext<Context>(ServiceLifetime.Scoped);

IMapper mapper = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserRequest, UserModel>();
    cfg.CreateMap<UserUpdateRequest, UserModel>();
    cfg.CreateMap<UserModel, UserResponse>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
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

app.Run();
