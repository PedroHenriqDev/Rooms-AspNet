using System.Data;
using Rooms.Domain.Entities;
using Rooms.Domain.Repositories;
using Rooms.Infra.Repositories.Abstractions;

namespace Rooms.Infra.Repositories;

public class RoomRepository : Repository<Room>, IRoomRepository
{
    public RoomRepository(IDbConnection connection) : base(connection)
    {
    }
}