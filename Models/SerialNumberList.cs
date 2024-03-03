using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

[Table("SerialNumberList")]
public  class SerialNumberList
{
    [Key]
    public Guid Id { get; set; }

    public Guid ShipmentItemId { get; set; }

    [StringLength(50)]
    public required Guid CustomerId { get; set; }

    [StringLength(50)]
    public string? FrameNumber { get; set; }

    [StringLength(50)]
    public string? Serialnumber { get; set; }

    [StringLength(50)]
    public string? BatteryNumber { get; set; }

    [StringLength(50)]
    public string? ProductionNumber { get; set; }

    [StringLength(50)]
    public string? SerialNumberDisplay { get; set; }

    [StringLength(50)]
    public string? KeyNumberFrameLock { get; set; }

    [StringLength(50)]
    public string? KeyNumberBattery { get; set; }

    [StringLength(50)]
    public string? MotorNumber { get; set; }

    [StringLength(50)]
    public string? GearHubNumber { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Created { get; set; }
}
