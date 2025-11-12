using Microsoft.EntityFrameworkCore;
using CitiesApp.Api.Models;

namespace CitiesApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; } = null!;
    }
}
