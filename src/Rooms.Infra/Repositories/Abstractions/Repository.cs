using System.Data;
using Dapper.Contrib.Extensions;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Repositories;

namespace Rooms.Infra.Repositories.Abstractions;

public abstract class Repository<T> : IRepository<T> where T : Entity
{
    private readonly IDbConnection _connection;

    public Repository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _connection.GetAllAsync<T>();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _connection.GetAsync<T>(id);
    }

    public async Task<bool> CreateAsync(T entity)
    {
        int rowsAffected = await _connection.InsertAsync(entity);
        return rowsAffected >= 1;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        return await _connection.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        return await _connection.DeleteAsync(entity);
    }
}