using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("Order")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public required Guid DeliveryAdress { get; set; }
    public bool IsNew { get; set; }
    public bool IsCompleted { get; set; }
    public string? OrderState { get; set; }
    public string? Payment { get; set; }
    public string? Reference { get; set; }
    public string? Notice { get; set; }
    public string? TrackingNumber { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime OrderRecievedDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}
