using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.Core.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [MaxLength(100)]
    public required string ProductName { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }

    public int UnitsInStock { get; set; }
    public int ReorderLevel { get; set; }

    [MaxLength(500)]
    public string PhotoUrl { get; set; } = string.Empty;

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public required Category Category { get; set; }

    [Required]
    public int SupplierId { get; set; }

    [Required]
    public required Supplier Supplier { get; set; }
}
