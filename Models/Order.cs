using ECommerce.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("Order")]
public class Order
{
    [Key]
    public required Guid Id { get; set; }
    
    public required Guid CustomerId { get; set; }
    
    public required Guid DeliveryAdressId { get; set; }
    
    public required string OrderState { get; set; }
    
    public string? Payment { get; set; }
    
    public required bool IsPayed { get; set; }
    
    public string? Reference { get; set; }
    
    public string? Notice { get; set; }
    
    public string? TrackingNumber { get; set; }
    
    public required bool IsNew { get; set; }
    
    public required bool IsCompleted { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime OrderRecievedDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}
