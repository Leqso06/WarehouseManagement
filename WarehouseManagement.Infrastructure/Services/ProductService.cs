using Mapster;
using WarehouseManagement.Core.Common;
using WarehouseManagement.Core.DTOs;
using WarehouseManagement.Core.Entities;
using WarehouseManagement.Core.Interfaces.Repositories;
using WarehouseManagement.Core.Interfaces.Services;

namespace WarehouseManagement.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISupplierRepository _supplierRepository;

    public ProductService(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        ISupplierRepository supplierRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _supplierRepository = supplierRepository;
    }

    public async Task<ServiceResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return ServiceResult<IEnumerable<ProductDto>>.Ok(products.Adapt<IEnumerable<ProductDto>>());
    }

    public async Task<ServiceResult<PagedResult<ProductDto>>> GetAllProductsAsync(int page, int pageSize)
    {
        var paged = await _productRepository.GetAllAsync(page, pageSize);
        var dto = PagedResult<ProductDto>.Create(
            paged.Items.Adapt<IEnumerable<ProductDto>>(),
            paged.TotalCount,
            paged.Page,
            paged.PageSize);

        return ServiceResult<PagedResult<ProductDto>>.Ok(dto);
    }

    public async Task<ServiceResult<IEnumerable<ProductDto>>> SearchProductsAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return ServiceResult<IEnumerable<ProductDto>>.Fail("Search term cannot be empty.");

        var products = await _productRepository.SearchByNameAsync(name);
        return ServiceResult<IEnumerable<ProductDto>>.Ok(products.Adapt<IEnumerable<ProductDto>>());
    }

    public async Task<ServiceResult<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(int categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category == null)
            return ServiceResult<IEnumerable<ProductDto>>.NotFound($"Category with id {categoryId} was not found.");

        var products = await _productRepository.GetByCategoryIdAsync(categoryId);
        return ServiceResult<IEnumerable<ProductDto>>.Ok(products.Adapt<IEnumerable<ProductDto>>());
    }

    public async Task<ServiceResult<IEnumerable<ProductDto>>> GetLowStockProductsAsync()
    {
        var products = await _productRepository.GetLowStockProductsAsync();
        return ServiceResult<IEnumerable<ProductDto>>.Ok(products.Adapt<IEnumerable<ProductDto>>());
    }

    public async Task<ServiceResult<ProductDto>> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return ServiceResult<ProductDto>.NotFound($"Product with id {id} was not found.");

        return ServiceResult<ProductDto>.Ok(product.Adapt<ProductDto>());
    }

    public async Task<ServiceResult<IEnumerable<CategoryDto>>> GetCategoriesForFormAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return ServiceResult<IEnumerable<CategoryDto>>.Ok(categories.Adapt<IEnumerable<CategoryDto>>());
    }

    public async Task<ServiceResult<IEnumerable<SupplierDto>>> GetSuppliersForFormAsync()
    {
        var suppliers = await _supplierRepository.GetAllAsync();
        return ServiceResult<IEnumerable<SupplierDto>>.Ok(suppliers.Adapt<IEnumerable<SupplierDto>>());
    }

    public async Task<ServiceResult<ProductDto>> CreateProductAsync(CreateProductDto dto)
    {
        var categoryExists = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (categoryExists == null)
            return ServiceResult<ProductDto>.NotFound($"Category with id {dto.CategoryId} was not found.");

        var supplierExists = await _supplierRepository.GetByIdAsync(dto.SupplierId);
        if (supplierExists == null)
            return ServiceResult<ProductDto>.NotFound($"Supplier with id {dto.SupplierId} was not found.");

        var product = dto.Adapt<Product>();
        var created = await _productRepository.CreateAsync(product);

        // Re-fetch to populate Category and Supplier navigation properties for mapping
        var full = await _productRepository.GetByIdAsync(created.ProductId);
        return ServiceResult<ProductDto>.Ok(full!.Adapt<ProductDto>());
    }

    public async Task<ServiceResult<bool>> UpdateProductAsync(int id, UpdateProductDto dto)
    {
        if (dto.CategoryId.HasValue)
        {
            var categoryExists = await _categoryRepository.GetByIdAsync(dto.CategoryId.Value);
            if (categoryExists == null)
                return ServiceResult<bool>.NotFound($"Category with id {dto.CategoryId.Value} was not found.");
        }

        if (dto.SupplierId.HasValue)
        {
            var supplierExists = await _supplierRepository.GetByIdAsync(dto.SupplierId.Value);
            if (supplierExists == null)
                return ServiceResult<bool>.NotFound($"Supplier with id {dto.SupplierId.Value} was not found.");
        }

        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return ServiceResult<bool>.NotFound($"Product with id {id} was not found.");

        dto.Adapt(product);
        await _productRepository.UpdateAsync(product);
        return ServiceResult<bool>.Ok(true);
    }

    public async Task<ServiceResult<bool>> DeleteProductAsync(int id)
    {
        var result = await _productRepository.DeleteAsync(id);

        if (!result)
            return ServiceResult<bool>.NotFound($"Product with id {id} was not found.");

        return ServiceResult<bool>.Ok(true);
    }
}