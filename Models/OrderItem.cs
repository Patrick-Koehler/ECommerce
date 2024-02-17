using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("OrderItem")]
public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }
    public required Guid ProductId { get; set; }
    public required string ProductNumber { get; set; }
    public required string Description { get; set; }
    public double Quantity { get; set; }
    public required decimal RetailPriceNet { get; set; }
    public required decimal RetailPrice { get; set; }
    public required double VAT { get; set; }
    public required decimal VATAmount { get; set; }
    public required string Payment { get; set; }
    
    [Column(TypeName = "smalldatetime")]    
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Modified { get; set; }
}
