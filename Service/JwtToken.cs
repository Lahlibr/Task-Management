using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Task_Management.Models;
namespace Task_Management.Service
{
    public class JwtToken
    {
        public class JwtHelper
        {
            private readonly IConfiguration _config;
            public JwtHelper(IConfiguration configuration) { 
                _config = configuration;
            }
            public string GenerateToken(User user)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims:claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }
}
