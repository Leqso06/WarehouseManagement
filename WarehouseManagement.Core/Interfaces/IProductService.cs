using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagement.Core.DTOs;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Core.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();

    Task<ProductDto> GetProductByIdAsync(int id);
    Task<ProductFormDto> GetProductForEditAsync(int id);

    Task<int> CreateProductAsync(ProductFormDto dto);

    Task<bool> UpdateProductAsync(int id, ProductFormDto dto);

    Task<bool> DeleteProductAsync(int id);

    Task<IEnumerable<ProductDto>> SearchProductsAsync(string name);

    Task<IEnumerable<ProductDto>> GetLowStockProductsAsync();
}