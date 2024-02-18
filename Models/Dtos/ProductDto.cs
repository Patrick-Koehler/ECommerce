using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.Dtos
{
    public class ProductDto
    {
        public required Guid Id { get; set; }
        public required string ProductNumber { get; set; }

        public required string Description { get; set; }

        public Guid Color { get; set; }

        public Guid Size { get; set; }

        public string? ClassificationSchemeGroup { get; set; }

        public string? Cathegory { get; set; }

        public string? Manufacturer { get; set; }

        public bool IsBike { get; set; }

        public bool IsMain { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? AvailableFrom { get; set; }
    }
}
