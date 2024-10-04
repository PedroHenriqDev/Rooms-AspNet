using System.Data;
using Rooms.Domain.Entities;
using Rooms.Domain.Repositories;
using Rooms.Infra.Repositories.Abstractions;

namespace Rooms.Infra.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(IDbConnection connection) : base(connection)
    {
    }
}