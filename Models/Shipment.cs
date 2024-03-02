using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Shipment
    {
        [Key]
        public required Guid Id { get; set; }
        
        public required Guid CustomerId { get; set; }
        
        public required Guid DeliveryAdressId { get; set; }

        public required string ShipmentNumber { get; set; }
        
        public required string OrderNumber { get; set; }

        [Column(TypeName = "smalldatetime")]
        public required DateTime Created { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Modified { get; set; }
    }
}
