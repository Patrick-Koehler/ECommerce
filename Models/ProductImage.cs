using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("ProductImage")]
public class ProductImage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }
    public required Guid ProductId { get; set; }
    public required string ProductNumber { get; set; }
    public required string ProductDescription { get; set; }
    public string? ImageDescription { get; set; }
    public Guid? ProductVariantId { get; set; }
    public string? ProductVariantNumber { get; set; }
    public int? Position { get; set; }
    public string? URL { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}