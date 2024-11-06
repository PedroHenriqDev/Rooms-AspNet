using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Filters.Abstractions;

namespace Rooms.Domain.Repositories;

public interface IRepository<TEntity, TFilter> 
    where TEntity : Entity 
    where TFilter : Filter
{
    Task<IEnumerable<TEntity>> GetAllAsync(int offSet, int size);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetByFilterAsync(TFilter filter);
    Task<bool> CreateAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<int> CountAsync();
}