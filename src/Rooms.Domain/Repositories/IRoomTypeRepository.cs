using Rooms.Domain.Entities;
using Rooms.Domain.Filters;

namespace Rooms.Domain.Repositories;

public interface IRoomTypeRepository : IRepository<RoomType, RoomFilter>
{
    Task<bool> ExistsNameAsync(string name);
}