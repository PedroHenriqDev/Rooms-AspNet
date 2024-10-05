using System.Data;
using Dapper;
using Rooms.Domain.Entities;
using Rooms.Domain.Repositories;

namespace Rooms.Infra.Repositories;

public sealed class PersonRepository : IPersonRepository
{
    private readonly IDbConnection _connection;

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

        return await _connection.QueryAsync<Person>(
            sql: "SP_Persons_Get_All",
            param: param,
            commandType: CommandType.StoredProcedure
        );
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
}