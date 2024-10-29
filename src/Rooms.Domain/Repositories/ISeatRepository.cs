using Rooms.Domain.Entities;
using Rooms.Domain.Filters.Abstractions;

namespace Rooms.Domain.Repositories;

public interface ISeatRepository : IRepository<Seat, Filter>
{
}