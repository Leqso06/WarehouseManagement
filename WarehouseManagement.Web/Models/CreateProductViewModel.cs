using WarehouseManagement.Core.DTOs;

namespace WarehouseManagement.Web.Models;
public class CreateProductViewModel
{
    public CreateProductDto Product { get; set; }
    public IEnumerable<CategoryDto> Categories { get; set; }
    public IEnumerable<SupplierDto> Suppliers { get; set; }
}
