using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Poker.Service.DTOs.Token;
using Poker.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Poker.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //TODO azure key vault
        public TokenResponse GenerateToken(TokenRequest tokenRequest)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, tokenRequest.Email),
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

            return new TokenResponse()
            {
                Token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }

        public bool Validate(TokenRequest tokenRequest)
        {
            return true;
        //    return userInfo.Username == "" && userInfo.Password == "";
        }
    }
}
