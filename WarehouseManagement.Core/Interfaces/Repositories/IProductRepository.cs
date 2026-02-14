using WarehouseManagement.Core.Common;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Core.Interfaces.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    new Task<IEnumerable<Product>> GetAllAsync();
    new Task<PagedResult<Product>> GetAllAsync(int page, int pageSize);
    new Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> SearchByNameAsync(string name);
    Task<IEnumerable<Product>> GetLowStockProductsAsync();
    Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
}