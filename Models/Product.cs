using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("Product")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }
    
    public required string ProductNumber { get; set; }
    
    public required string Description { get; set; }

    public string? Description2 { get; set; }
    
    public Guid Color { get; set; }

    public Guid Size { get; set; }
    
    public string? ClassificationSchemeGroup { get; set; }

    public string? Cathegory { get; set; }
    
    public string? Manufacturer { get; set; }

    public bool IsBike { get; set; }

    public bool IsMain { get; set; }
    
    public int? EAN { get; set; }
    
    public string? ManufacturerNumber { get; set; }
    
    public decimal RetailPrice { get; set; }
    
    public decimal RRP { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? AvailableFrom { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}