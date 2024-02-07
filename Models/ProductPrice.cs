using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("ProductPrice")]
public class ProductPrice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public required Guid ProductId { get; set; }
    public decimal PurchasePriceNet { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal RetailPriceNet { get; set; }
    public decimal RetailPrice { get; set; }
    public decimal RRP { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Modified { get; set; }
}
