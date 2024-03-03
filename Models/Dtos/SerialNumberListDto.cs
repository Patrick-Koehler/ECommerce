using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Dtos;

public class SerialNumberListDto
{
    public string? FrameNumber { get; set; }

    public string? Serialnumber { get; set; }
    
    public string? BatteryNumber { get; set; }

    public string? ProductionNumber { get; set; }

    public string? SerialNumberDisplay { get; set; }

    public string? KeyNumberFrameLock { get; set; }

    public string? KeyNumberBattery { get; set; }

    public string? MotorNumber { get; set; }

    public string? GearHubNumber { get; set; }
}
