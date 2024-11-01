using System.Data;
using Dapper;
using Rooms.Domain.Entities;
using Rooms.Domain.Filters.Abstractions;
using Rooms.Domain.Repositories;
using Rooms.Domain.ValueObjects;

namespace Rooms.Infra.Repositories;

public sealed class PersonRepository : IPersonRepository
{
    private readonly IDbConnection _connection;

    private Func<Guid, DateTime, string, string, DateTime, Guid, Person> mapPerson => (id, createdAt, firstName, lastName, birthDate, seatId) =>
    {
        return new Person(id, createdAt, new Name(firstName, lastName), new Age(birthDate), seatId);
    };

    public PersonRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Person>> GetAllAsync(int offSet, int size)
    {
        object param = new
        {
            OffSet = offSet,
            Size = size 
        };

        var personsDict = new Dictionary<Guid, Person>();

        var persons = await _connection.QueryAsync<Person, Name, Age, Guid, Person>(
            sql: "SP_Persons_Get_All",
            param: param,
            commandType: CommandType.StoredProcedure,
            map: (person, name, age, seatId) =>
            {
                var personEntry = new Person(person.Id, person.CreatedAt, name, age, seatId);

                if (!personsDict.TryGetValue(person.Id, out _))
                {
                    personsDict.Add(personEntry.Id, personEntry);
                }

                return personEntry;
            },
            splitOn: "FirstName,BirthDate,SeatId"
        );

        return personsDict.Values;
    }

    public async Task<Person?> GetByIdAsync(Guid id)
    {
        return await _connection.QueryFirstOrDefaultAsync<Person>(
            sql: "SP_Persons_Get_By_Id",
            param: new { Id = id },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<bool> CreateAsync(Person entity)
    {
        object param = new
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            FirstName = entity.Name.FirstName,
            LastName = entity.Name.LastName,
            BirthDate = entity.Age.BirthDate,
            SeatId = entity.SeatId
        };

        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Persons_Create",
            param: param,
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Persons_Delete",
            param: new { Id = id},
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }

    public async Task<bool> UpdateAsync(Person entity)
    {
        object param = new
        {
            Id = entity.Id,
            FirstName = entity.Name.FirstName,
            LastName = entity.Name.LastName,
            BirthDate = entity.Age.BirthDate,
            SeatId = entity.SeatId
        };

        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Persons_Update",
            param: param,
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }

    public async Task<int> CountAsync()
    {
        return await _connection.ExecuteScalarAsync<int>
        (
            sql: "SP_Persons_Count",
            commandType: CommandType.StoredProcedure
        );
    }

    public Task<IEnumerable<Person>> GetByFilterAsync(Filter filter)
    {
        throw new NotImplementedException();
    }
}