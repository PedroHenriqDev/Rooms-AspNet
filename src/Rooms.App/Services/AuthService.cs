using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rooms.App.Dtos;
using Rooms.App.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rooms.App.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AuthenticationDto Authenticate(IList<Claim> claims)
    {
        (DateTime expireDate, string key, string audience, string issuer) = GetTokenConfig();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Audience = audience,
            Issuer = issuer,
            Expires = expireDate,
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                                 Encoding.ASCII.GetBytes(key)),
                                 SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new AuthenticationDto(tokenHandler.WriteToken(token), DateTime.Now, expireDate);
    }
     
    private (DateTime expireDate, string key, string audience, string issuer) GetTokenConfig()
    {
        string hoursToExpire = _configuration["Jwt:Expire"] ?? throw new ArgumentNullException(nameof(hoursToExpire));
        var expireDate = DateTime.UtcNow.AddHours(Convert.ToInt32(hoursToExpire));
        string key = _configuration["Jwt:Key"] ?? throw new ArgumentNullException(nameof(key));
        string? audience = _configuration["Jwt:Audience"] ?? throw new ArgumentNullException(nameof(audience));
        string? issuer = _configuration["Jwt:Issuer"] ?? throw new ArgumentNullException(nameof(issuer));

        return (expireDate, key, audience, issuer);
    }
}
