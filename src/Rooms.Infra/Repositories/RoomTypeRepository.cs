using System.Data;
using Dapper;
using Rooms.Domain.Entities;
using Rooms.Domain.Filters;
using Rooms.Domain.Filters.Abstractions;
using Rooms.Domain.Repositories;
using Rooms.Infra.Utils;

namespace Rooms.Infra.Repositories;

public sealed class RoomTypeRepository : IRoomTypeRepository
{
    private readonly IDbConnection _connection;

    public RoomTypeRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<RoomType>> GetAllAsync(int offSet, int size)
    {
        object param = new
        {
            OffSet = offSet,
            Size = size
        };

        return await _connection.QueryAsync<RoomType>(
            sql: "SP_RoomTypes_Get_All",
            param: param,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<RoomType?> GetByIdAsync(Guid id)
    {
        return await _connection.QueryFirstOrDefaultAsync<RoomType>(
            sql: "SP_RoomTypes_Get_By_Id",
            param: new { Id = id },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<IEnumerable<RoomType>> GetByFilterAsync(RoomTypeFilter filter)
    {
        filter.Sanitize();
  
        return await _connection.QueryAsync<RoomType>
        (
            sql: "SP_RoomTypes_Get_By_Filters",
            param: filter,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<bool> ExistsNameAsync(string name)
    {
        object parameters = new { Name = name };

        return await _connection.QueryFirstOrDefaultAsync<bool>(
            sql: "SP_RoomTypes_Exists_Name",
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<int> CountAsync()
    {
        return await _connection.ExecuteScalarAsync<int>
        (
            sql: "SP_RoomTypes_Count",
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<bool> CreateAsync(RoomType entity)
    {
        object param = new
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Name = entity.Name
        };

        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_RoomTypes_Create",
            param: param,
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }

    public async Task<bool> UpdateAsync(RoomType entity)
    {
        object param = new
        {
            Id = entity.Id,
            Name = entity.Name
        };

        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_RoomTypes_Update",
            param: param,
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_RoomTypes_Delete",
            param: new { Id = id },
            commandType: CommandType.StoredProcedure
        );

        return rowsAffected > 0;
    }
}