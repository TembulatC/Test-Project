using Domain.Models;
using Domain.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.JWT
{
    public class JWTProvider : IJWTProviderRepository
    {
        private readonly JWTOptions _options;

        public JWTProvider(IOptions<JWTOptions> options)
        {
            _options = options.Value;
        }

        // Параметры для создания jwt токена
        public string GenerateToken(Client client)
        {
            Claim[] claims = [new("userId", client.Id.ToString())];

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.secretKey)), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.expitesHours)
                );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
