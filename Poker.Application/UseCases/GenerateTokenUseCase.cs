using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Poker.Service.Interfaces.UseCases;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Poker.Service.UseCases
{
    public class GenerateTokenUseCase : IGenerateTokenUseCase
    {
        private readonly IConfiguration _configuration;
        public GenerateTokenUseCase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public (string, DateTime) Execute(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds);

            return ("Bearer " + new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);
        }
    }
}
