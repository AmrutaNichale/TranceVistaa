using Microsoft.EntityFrameworkCore;
using TranceVista.Data;
using TranceVista.Interfaces;
using TranceVista.Models;

namespace TranceVista.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly ApplicationDbContext _context;

        public DestinationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destinations.ToListAsync();
        }

        public async Task<Destination?> GetByIdAsync(int id)
        {
            return await _context.Destinations.FindAsync(id);
        }

        public async Task<Destination> AddAsync(Destination destination)
        {
            _context.Destinations.Add(destination);

            await _context.SaveChangesAsync();

            return destination;
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Entry(destination).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);

            if (destination != null)
            {
                _context.Destinations.Remove(destination);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Destination>> SearchAsync(
    string? city,
    string? country,
    decimal? maxBudget)
        {
            var query = _context.Destinations.AsQueryable();

            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(d => d.City.Contains(city));
            }

            if (!string.IsNullOrWhiteSpace(country))
            {
                query = query.Where(d => d.Country.Contains(country));
            }

            if (maxBudget.HasValue)
            {
                query = query.Where(d => d.EstimatedBudget <= maxBudget.Value);
            }

            return await query.ToListAsync();
        }
    }
}