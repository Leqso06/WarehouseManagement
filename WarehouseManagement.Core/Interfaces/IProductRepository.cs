using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Core.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IEnumerable<Product>> SearchByNameAsync(string name);
    Task<IEnumerable<Product>> GetLowStockProductsAsync();
    Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
}