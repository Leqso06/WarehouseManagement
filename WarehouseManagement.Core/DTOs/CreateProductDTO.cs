namespace WarehouseManagement.Core.DTOs;

public class CreateProductDTO
{
    public required string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int ReorderLevel { get; set; }
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public string? PhotoUrl { get; set; }
}