using AutoMapper;
using IdentityAPI.Data.DTOs;
using IdentityAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityAPI.Services
{
    public class TokenService
    {
        internal string GenerateToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim("UserName", user.UserName),
                new Claim("Id", user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AmauriJuniorIdentyAPITestDeAutenticacaocomJWT"));

            var signIncredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                
                expires: DateTime.UtcNow.AddMinutes(10),
                claims: claims,
                signingCredentials: signIncredential
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
