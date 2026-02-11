using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Core.Interfaces;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
}