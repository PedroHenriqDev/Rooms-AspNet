using Dapper;
using Rooms.Domain.Entities;
using Rooms.Domain.Enums;
using Rooms.Domain.Filters.Abstractions;
using Rooms.Domain.Repositories;
using Rooms.Domain.ValueObjects;
using System.Data;

namespace Rooms.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _connection;
    private const string SPLIT_ON = "BirthDate,Role,Salt";

    private Func<User, Age, int, string, User> mapUsers(Dictionary<Guid, User> usersDict) => (user, age, role, salt) =>
    {
        var userEntry = new User(user.Id, user.CreatedAt, user.Name, user.Age, user.Email, user.Password, salt, (EUserRole)role);
    
        if (!usersDict.TryGetValue(userEntry.Id, out _))
        {
            usersDict.Add(user.Id, userEntry);
        }

        return user;
    };

    public UserRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<User>> GetAllAsync(int offSet, int size)
    {
        object parameters = new
        {
            OffSet = offSet,
            Size = size
        };

        var usersDict = new Dictionary<Guid, User>();

        _ = await _connection.QueryAsync<User, Age, int, string, User>(
            sql: "SP_Users_Get_All",
            commandType: CommandType.StoredProcedure,
            map: mapUsers(usersDict),
            splitOn: SPLIT_ON);

        return usersDict.Values;
    }

    public async Task<User?> GetByNameAsync(string name)
    {
        object parameters = new
        {
            Name = name
        };

        var usersDict = new Dictionary<Guid, User>();

        _ = await _connection.QueryAsync<User, Age, int, string, User>(
            sql: "SP_Users_Get_By_Name",
            commandType: CommandType.StoredProcedure,
            param: parameters,
            map: mapUsers(usersDict),
            splitOn: SPLIT_ON);

        return usersDict.Values.FirstOrDefault();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        object parameters = new
        {
            Email = email
        };

        var usersDict = new Dictionary<Guid, User>();

        _ = await _connection.QueryAsync<User, Age,int, string, User>(
            sql: "SP_Users_Get_By_Email",
            commandType: CommandType.StoredProcedure,
            param: parameters,
            map: mapUsers(usersDict),
            splitOn: SPLIT_ON);

        return usersDict?.Values.FirstOrDefault();
    }

    public Task<IEnumerable<User>> GetByFilterAsync(Filter filter)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(User entity)
    {
        object parameters = new
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Name = entity.Name,
            Password = entity.Password,
            Salt = entity.Salt,
            Email = entity.Email,
            BirthDate = entity.Age.BirthDate,
            Role = entity.Role
        };

        int rowsAffected = await _connection.ExecuteAsync(
            sql: "SP_Users_Create",
            commandType: CommandType.StoredProcedure,
            param: parameters);

        return rowsAffected > 0;
    }

    public Task<bool> DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }


    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsNameAsync(string name)
    {
        return await _connection.QueryFirstOrDefaultAsync<bool>(
            sql: "SP_Users_Exists_Name",
            param: new { Name = name },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> ExistsEmailAsync(string email)
    {
        return await _connection.QueryFirstOrDefaultAsync<bool>(
            sql: "SP_Users_Exists_Email",
            param: new { Email = email},
            commandType: CommandType.StoredProcedure);
    }
}
