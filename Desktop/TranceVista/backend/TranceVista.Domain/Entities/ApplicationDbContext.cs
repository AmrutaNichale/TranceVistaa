using Microsoft.EntityFrameworkCore;
using TranceVista.Domain.Entities;

namespace TranceVista.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Destination> Destinations => Set<Destination>();
    }
}