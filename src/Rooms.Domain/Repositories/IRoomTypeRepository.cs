using Rooms.Domain.Entities;

namespace Rooms.Domain.Repositories;

public interface IRoomTypeRepository : IRepository<RoomType>
{
    Task<bool> ExistsNameAsync(string name);
}