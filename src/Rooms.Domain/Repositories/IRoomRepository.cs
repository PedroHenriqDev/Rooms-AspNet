using Rooms.Domain.Entities;
using Rooms.Domain.Filters.Abstractions;

namespace Rooms.Domain.Repositories;

public interface IRoomRepository : IRepository<Room, Filter>
{
}