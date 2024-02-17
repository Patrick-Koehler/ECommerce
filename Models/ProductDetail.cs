using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("ProductDetail")]
public class ProductDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }
    public required Guid ProductId { get; set; }
    public required string ProductNumber { get; set; }
    public string? Description2 { get; set; }
    public int? EAN { get; set; }
    public string? ManufacturerNumber { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Modified { get; set; }
}
