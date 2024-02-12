using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("Product")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public required string ProductNumber { get; set; }
    
    public required string ProductDescription { get; set; }

    public string? ProductDescription2 { get; set; }

    public int? EAN { get; set; }
    
    public string? ClassificationSchemeGroup { get; set; }

    public string? Cathegory { get; set; }
    
    public string? Manufacturer { get; set; }
    
    public string? ManufacturerNumber { get; set; }

    public decimal? RetailPrice { get; set; }
    
    public decimal? RRP { get; set; }

    public bool IsBike { get; set; }

    public bool IsMain { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }
    
    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? AvailableFrom { get; set; }
}