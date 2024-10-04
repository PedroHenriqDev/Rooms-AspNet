using System.Data;
using Dapper;
using Rooms.Domain.Entities;
using Rooms.Domain.Repositories;
using Rooms.Infra.Repositories.Abstractions;

namespace Rooms.Infra.Repositories;

public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(IDbConnection connection) : base(connection)
    {
    }

    public async Task<bool> ExistsNameAsync(string name)
    {
        var parameters = new { Name = name };

        return await _connection.QueryFirstOrDefaultAsync<bool>(
            sql: "SP_RoomTypes_Exists_Name",
            param: parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}