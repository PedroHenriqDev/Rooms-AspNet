using System.Data;
using Dapper;
using Rooms.Domain.Entities;
using Rooms.Domain.Repositories;

namespace Rooms.Infra.Repositories;

public sealed class RoomRepository : IRoomRepository
{
    private readonly IDbConnection _connection;

    public RoomRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<IEnumerable<Room>> GetAllAsync(int offSet, int size)
    {
        object param = new
        {
            OffSet = offSet,
            Size = size 
        };

        return await _connection.QueryAsync<Room>(
            sql: "SP_Rooms_Get_All",
            param: param,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<Room?> GetByIdAsync(Guid id)
    {
        return await _connection.QueryFirstOrDefaultAsync(
            sql: "SP_Rooms_Get_By_Id",
            param: new { Id = id },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<bool> CreateAsync(Room entity)
    {
        object param = new
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Name = entity.Name,
            Capacity = entity.Capacity,
            RoomTypeId = entity.TypeId,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            SoldOut = entity.SoldOut
        };

        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Rooms_Create",
            param: param,
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Rooms_Delete",
            param: new { Id = id},
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }

    public async Task<bool> UpdateAsync(Room entity)
    {
        object param = new
        {
            Id = entity.Id,
            Name = entity.Name,
            Capacity = entity.Capacity,
            RoomTypeId = entity.TypeId,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            SoldOut = entity.SoldOut
        };

        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Rooms_Update",
            param: param,
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }

    public async Task<int> CountAsync()
    {
        return await _connection.ExecuteScalarAsync<int>
        (
            sql: "SP_Rooms_Count",
            commandType: CommandType.StoredProcedure
        );
    }
}