using Rooms.Domain.Entities;
using Rooms.Domain.Filters.Abstractions;

namespace Rooms.Domain.Repositories;

public interface IPersonRepository : IRepository<Person, Filter>
{
}