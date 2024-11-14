using Rooms.App.Dtos;
using System.Security.Claims;

namespace Rooms.App.Services.Interfaces;

public interface IAuthService
{
    AuthenticationDto Authenticate(IList<Claim> claims);
}
