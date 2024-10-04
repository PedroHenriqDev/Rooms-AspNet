using System.Data;
using Rooms.Domain.Entities;
using Rooms.Domain.Repositories;
using Rooms.Infra.Repositories.Abstractions;

namespace Rooms.Infra.Repositories;

public class SeatRepository : Repository<Seat>, ISeatRepository
{
    public SeatRepository(IDbConnection connection) : base(connection)
    {
    }
}