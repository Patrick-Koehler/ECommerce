using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriCommerce.Models;

[Table("ProductVariant")]
public class ProductVariant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public int ProductVariantNumber { get; set; }
    public string ProductVariantDescription { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}