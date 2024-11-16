using Rooms.App.Dtos;
using Rooms.Domain.Commands.Requests.Users;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services.Interfaces;

public interface IUserService
{
    Task<IResponse> RegisterAsync(CreateUserRequest request);
    Task<IResponse> GetByNameAsync(string name);
    Task<IResponse> GetByEmailAsync(string email);
    Task<IResponse> LoginAsync(LoginDto login);
}
