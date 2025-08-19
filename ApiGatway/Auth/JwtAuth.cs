using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiGatway.Auth
{
    public class JwtAuth
    {
        private readonly IConfiguration _config;

        public JwtAuth(IConfiguration config) 
        {
            _config = config;
        }

        public string GenerateJwt(long UserId, string Email)
        { 
            string SecretKey = _config.GetSection("JwtSettings:SecretKey").Value;
            string Issuer = _config.GetSection("JwtSettings:Issuer").Value;
            string Audience = _config.GetSection("JwtSettings:Audience").Value;
            int ExpiryMinutes = Convert.ToInt32(_config.GetSection("JwtSettings:ExpiryMinutes").Value);

            var secureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(secureKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                Issuer,
                Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(ExpiryMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
