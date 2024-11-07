using Rooms.Domain.Entities;
using Rooms.Domain.Filters;

namespace Rooms.Domain.Repositories;

public interface IPersonRepository : IRepository<Person, PersonFilter>
{
}