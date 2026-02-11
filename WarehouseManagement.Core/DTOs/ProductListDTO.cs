namespace WarehouseManagement.Core.DTOs;

public class ProductListDTO
{
    public int Id { get; set; }
    public required string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public required string CategoryName { get; set; }
    public required string SupplierName { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
}
