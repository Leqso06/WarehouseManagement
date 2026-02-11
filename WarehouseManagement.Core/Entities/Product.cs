namespace WarehouseManagement.Core.Entities;

public class Product
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public int ReorderLevel { get; set; }
    public string? PhotoUrl { get; set; }
}
