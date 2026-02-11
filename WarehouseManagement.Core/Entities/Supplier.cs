using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Core.Entities;

public class Supplier
{
    [Key]
    public int SupplierId { get; set; }

    [Required]
    [MaxLength(100)]
    public required string SupplierName { get; set; } = string.Empty;

    public ICollection<Product>? Products { get; set; }
}
