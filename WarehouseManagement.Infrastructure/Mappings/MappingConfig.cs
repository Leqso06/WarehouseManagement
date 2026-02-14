using Mapster;
using WarehouseManagement.Core.DTOs;
using WarehouseManagement.Core.Entities;

namespace WarehouseManagement.Infrastructure.Mappings;

public static class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<Product, ProductDto>.NewConfig()
            .Map(dest => dest.CategoryName, src => src.Category.CategoryName)
            .Map(dest => dest.SupplierName, src => src.Supplier.SupplierName);

        TypeAdapterConfig<UpdateProductDto, Product>.NewConfig()
            .IgnoreNullValues(true);
    }
}
