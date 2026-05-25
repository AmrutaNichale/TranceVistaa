using TranceVista.Models;

namespace TranceVista.Interfaces
{
    public interface IDestinationRepository
    {
        Task<IEnumerable<Destination>> GetAllAsync();

        Task<Destination?> GetByIdAsync(int id);

        Task<Destination> AddAsync(Destination destination);

        Task UpdateAsync(Destination destination);

        Task DeleteAsync(int id);

        Task<IEnumerable<Destination>> SearchAsync(string? city, string? country, decimal? maxBudget);
    }
}