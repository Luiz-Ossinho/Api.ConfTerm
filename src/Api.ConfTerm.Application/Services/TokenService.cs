using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Api.ConfTerm.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly byte[] secret;
        public TokenService(byte[] secret)
        {
            this.secret = secret;
        }
        public string GenerateTokenForUser(User user)
        {
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Type.Name),
                    new Claim("Email",user.Email.Value),
                    new Claim("Type",user.Type.Id.ToString())
            };

            var userDataDictionary = new Dictionary<string, string>
            {
                { "Email", user.Email.Value },
                { "Type", user.Type.Id.ToString() }
            };

            var jsonDictionary = JsonSerializer.Serialize(userDataDictionary);

            claims.Add(new Claim(ClaimTypes.UserData, jsonDictionary));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
