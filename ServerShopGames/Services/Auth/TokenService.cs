using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ShopGames.Models;
using Microsoft.IdentityModel.Tokens;
using ShopGames.DTOs;
using ShopGames.Services.Auth.Settings;

namespace ShopGames.Services.Auth
{
    public class TokenService
    {
        public static string GenerateToken(LoginDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SetSecrets.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.NmMail),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}