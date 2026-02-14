using WarehouseManagement.Core.Common;
using WarehouseManagement.Core.DTOs;

namespace WarehouseManagement.Core.Interfaces.Services;

public interface IProductService
{
    // Main page - product grid (unpaged)
    Task<ServiceResult<IEnumerable<ProductDto>>> GetAllProductsAsync();

    // Main page - product grid (paged)
    Task<ServiceResult<PagedResult<ProductDto>>> GetAllProductsAsync(int page, int pageSize);

    // Main page - search bar
    Task<ServiceResult<IEnumerable<ProductDto>>> SearchProductsAsync(string name);

    // Main page - category filter dropdown
    Task<ServiceResult<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(int categoryId);

    // Product detail page (view button)
    Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id);

    // Product creation form page (create button)
    Task<ServiceResult<IEnumerable<CategoryDto>>> GetCategoriesForFormAsync();
    Task<ServiceResult<IEnumerable<SupplierDto>>> GetSuppliersForFormAsync();
    Task<ServiceResult<ProductDto>> CreateProductAsync(CreateProductDto dto);

    // Product update form page (edit button)
    // GetProductByIdAsync is used for read
    Task<ServiceResult<bool>> UpdateProductAsync(int id, UpdateProductDto dto);

    // Product detail page (delete button)
    Task<ServiceResult<bool>> DeleteProductAsync(int id);

    // Main page - low stock indicator on cards
    Task<ServiceResult<IEnumerable<ProductDto>>> GetLowStockProductsAsync();
}