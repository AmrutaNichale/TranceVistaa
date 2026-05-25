using Microsoft.EntityFrameworkCore;
using TranceVista.Models;

namespace TranceVista.Data
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