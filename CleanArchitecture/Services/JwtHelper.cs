using $ext_safeprojectname$.Core.Configuration;
using $ext_safeprojectname$.Core.Interfaces;
using $ext_safeprojectname$.Core.Policies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace $ext_safeprojectname$.API.Services
{
    public class JwtHelper : ITokenClaimsService
    {
        private readonly JwtSettings _settings;

        public JwtHelper(IOptions<JwtSettings> options)
        {
            _settings = options.Value;
        }

        public TokenResponse GenerateToken(Core.Models.Identity identity) => GenerateJwtToken(identity);

        public TokenResponse GenerateJwtToken(Core.Models.Identity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(_settings.Expire);
            var claims = GenerateClaims(user);
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        private Claim[] GenerateClaims(Core.Models.Identity user)
        {
            return new Claim[]
            {
                new Claim(Claims.ClaimId, user.Id.ToString()),
                new Claim(Claims.ClaimUser, user.Id.ToString()),
                new Claim(Claims.ClaimEmail, user.Email ?? string.Empty),
                new Claim(Claims.ClaimRole, GetClaimRole(user.Role)),
            };
        }

        private string GetClaimRole(Core.Models.Role role)
        {
            switch (role)
            {
                case Core.Models.Role.Administrator: return Roles.Administrator;
                default: return string.Empty;
            }
        }
    }
}
