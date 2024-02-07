using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("Stock")]
public class Stock
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public required Guid ProductId { get; set; }
    public required int ProductNumber { get; set; }
    public Guid ProductVariantId { get; set; }
    public int ProductVariantNumber { get; set; }
    public Guid ProductColorId { get; set; }
    public Guid ProductSizeId { get; set; }
    public int InStock { get; set; }
    public int Reserved { get; set; }
    public int Ordered { get; set; }
    public int AvailabiltyStock { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}
