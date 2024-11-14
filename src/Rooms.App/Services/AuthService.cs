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
        (DateTime expireDate, string key) = GetTokenConfig();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Expires = expireDate,
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                                 Encoding.ASCII.GetBytes(key)),
                                 SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        return new AuthenticationDto(tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)), DateTime.Now, expireDate);
    }
     
    private (DateTime expireDate, string key) GetTokenConfig()
    {
        string hoursToExpire = _configuration["Jwt:Expire"] ?? throw new ArgumentNullException(nameof(hoursToExpire));
        var expireDate = DateTime.Now.AddHours(Convert.ToInt32(hoursToExpire));
        string key = _configuration["Jwt:Key"] ?? throw new ArgumentNullException(nameof(key));

        return (expireDate, key);
    }
}
