using Rooms.Domain.Entities;
using Rooms.Domain.Filters.Abstractions;

namespace Rooms.Domain.Repositories;

public interface IUserRepository : IRepository<User, Filter>
{
    Task<User?> GetByNameAsync(string name);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> ExistsNameAsync(string name);
    Task<bool> ExistsEmailAsync(string email);
}
