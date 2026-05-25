using System.ComponentModel.DataAnnotations;

namespace TranceVista.DTOs
{
    public class UpdateDestinationDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Range(1, 1000000)]
        public decimal EstimatedBudget { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}