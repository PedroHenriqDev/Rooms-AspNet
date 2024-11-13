using Rooms.Domain.Commands.Requests.Users;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services.Interfaces;

public interface IUserService
{
    Task<IResponse> RegisterAsync(CreateUserRequest request);
}
