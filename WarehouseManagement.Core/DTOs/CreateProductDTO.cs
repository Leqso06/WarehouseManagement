using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Core.DTOs;

public class CreateProductDto
{
    [Required]
    [MaxLength(100)]
    public string ProductName { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal UnitPrice { get; set; }

    [Range(0, int.MaxValue)]
    public int UnitsInStock { get; set; }

    [Range(0, int.MaxValue)]
    public int ReorderLevel { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int SupplierId { get; set; }

    [MaxLength(500)]
    public string PhotoUrl { get; set; } = string.Empty;
}
