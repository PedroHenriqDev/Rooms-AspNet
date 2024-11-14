using Rooms.App.Dto;
using Rooms.App.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Rooms.App.Services;

public class ClaimService : IClaimService
{
    public IList<Claim> GenerateAuthClaims(UserDto user)
    {
        var claims = new List<Claim>();
        
        if(user != null && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Email)) 
        {
            claims.AddRange(new List<Claim>()
            {
               new Claim(ClaimTypes.Name, user.Name),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.Role, user.Role),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            });
        }

        return claims;
    }
}
