using System.Data;
using Dapper;
using Rooms.Domain.Entities;
using Rooms.Domain.Repositories;

namespace Rooms.Infra.Repositories;

public sealed class SeatRepository : ISeatRepository
{
    private readonly IDbConnection _connection;

    public SeatRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task<IEnumerable<Seat>> GetAllAsync(int offSet, int size)
    {
        object param = new
        {
            OffSet = offSet,
            Size = size 
        };

        return _connection.QueryAsync<Seat>(
            sql: "SP_Seats_Get_All",
            param: param,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<Seat?> GetByIdAsync(Guid id)
    {
        return await _connection.QueryFirstOrDefaultAsync<Seat>(
            sql: "SP_Seats_Get_By_Id",
            param: new { Id = id },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<bool> CreateAsync(Seat entity)
    {
        object param = new
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Name = entity.Name,
            RoomId = entity.RoomId
        };

        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Seats_Create",
            param: param,
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Seats_Delete",
            param: new { Id = id },
            commandType: CommandType.StoredProcedure
        ); 
        
        return rowsAffected > 0;
    }

    public async Task<bool> UpdateAsync(Seat entity)
    {
        object param = new
        {
            Id = entity.Id,
            Name = entity.Name,
            RoomId = entity.RoomId
        };

        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Seats_Update",
            param: param,
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }
    
    public async Task<int> CountAsync()
    {
        return await _connection.ExecuteScalarAsync<int>
        (
            sql: "SP_Seats_Count",
            commandType: CommandType.StoredProcedure
        );
    }
}