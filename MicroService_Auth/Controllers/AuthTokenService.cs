using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MicroService_Auth.Models;
using Microsoft.IdentityModel.Tokens;

namespace MicroService_Auth.Controllers
{
    public class AuthTokenService
    {
        public AuthToken GenerateToken(AuthUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("placeholder-key-that-is-long-enough-for-sha256"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddHours(2);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(audience: "authAudience",
                issuer: "AuthIssuer",
                claims: claims,
                expires: expirationDate,
                signingCredentials: credentials);

            var authToken = new AuthToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expirationDate
            };

            return authToken;
        }
    }
}
