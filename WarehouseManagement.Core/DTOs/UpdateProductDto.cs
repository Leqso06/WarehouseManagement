using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Core.DTOs;

public class UpdateProductDto
{
    [MaxLength(100)]
    public string? ProductName { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal? UnitPrice { get; set; }

    public int? UnitsInStock { get; set; }
    public int? ReorderLevel { get; set; }
    public int? CategoryId { get; set; }
    public int? SupplierId { get; set; }
    public string? PhotoUrl { get; set; }
}
