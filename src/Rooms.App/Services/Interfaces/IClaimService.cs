using Rooms.App.Dto;
using System.Security.Claims;

namespace Rooms.App.Services.Interfaces;

public interface IClaimService
{
    IList<Claim> GenerateAuthClaims(UserDto user);
}
