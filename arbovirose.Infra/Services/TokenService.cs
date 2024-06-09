using arbovirose.Application.Services;
using arbovirose.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace arbovirose.Infra.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string? CreateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = _configuration["KEY:TOKEN"];
            if (key != null)
            {
                var keyEncoded = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.Profile.Office.value),
                        new Claim(ClaimTypes.Email, user.Email.value),
                        new Claim("primaryaccess", user.PrimaryAccess.ToString()),
                        new Claim("active", user.Active.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddHours(8),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyEncoded), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;
        }
    }
}
