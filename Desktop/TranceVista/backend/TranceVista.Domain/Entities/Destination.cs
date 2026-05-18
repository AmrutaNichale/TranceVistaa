namespace TranceVista.Domain.Entities
{
    public class Destination
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public decimal EstimatedBudget { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}