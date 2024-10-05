using Rooms.Domain.Entities.Abstractions;

namespace Rooms.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAllAsync(int offSet, int size);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<bool> CreateAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(Guid id);
}