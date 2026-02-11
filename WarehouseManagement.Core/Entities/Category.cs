using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Core.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    public required string CategoryName { get; set; } = string.Empty;
}
