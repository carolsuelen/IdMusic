using IdMusic.Application.AppClient.output;
using IdMusic.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdMusic.Api.Comum
{
    public class TokenService
    {
        public static string GenerateToken(ClientViewModel client, string secrets)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secrets);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, client.Name.ToString()),
                    new Claim(ClaimTypes.Role, client.Genre.Description),
                    new Claim(JwtRegisteredClaimNames.Jti, client.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(100),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler
                            .CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
