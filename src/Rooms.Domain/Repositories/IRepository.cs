using Rooms.Domain.Entities.Abstractions;

namespace Rooms.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    void CreateAsync(TEntity entity);
    void UpdateAsync(TEntity entity);
    void DeleteAsync(TEntity entity);
}