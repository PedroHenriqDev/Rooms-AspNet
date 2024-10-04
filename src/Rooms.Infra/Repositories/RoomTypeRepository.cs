using System.Data;
using Rooms.Domain.Entities;
using Rooms.Domain.Repositories;
using Rooms.Infra.Repositories.Abstractions;

namespace Rooms.Infra.Repositories;

public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(IDbConnection connection) : base(connection)
    {
    }
}