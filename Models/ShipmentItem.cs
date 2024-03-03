using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("ShipmentItem")]
public class ShipmentItem
{
    [Key]
    public required Guid Id { get; set; }

    public required Guid ProductId { get; set; }

    public required string ProductNumber { get; set; }

    public required string Description { get; set; }

    public double Quantity { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}
