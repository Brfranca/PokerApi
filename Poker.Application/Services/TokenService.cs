using Microsoft.IdentityModel.Tokens;
using Poker.Service.DTOs.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service.Services
{
    public class TokenService
    {
        public TokenResponse BuildToken(TokenRequest tokenRequest)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, tokenRequest.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("afsdkjasjflxswafsdklk434orqiwup3457u-34oewir4irroqwiffv48mfs"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(2);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new TokenResponse()
            {
                Token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        //internal bool Validate(TokenRequest userInfo)
        //{
        //    return userInfo.Username == "" && userInfo.Password == "";
        //}
    }
}
