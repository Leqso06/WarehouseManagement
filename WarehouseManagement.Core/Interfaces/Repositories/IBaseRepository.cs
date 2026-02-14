using WarehouseManagement.Core.Common;

namespace WarehouseManagement.Core.Interfaces.Repositories;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<PagedResult<T>> GetAllAsync(int page, int pageSize);
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
}