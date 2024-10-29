using Microsoft.EntityFrameworkCore;
using KalenderMVC.Models;

namespace KalenderMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Kasutajad> Kasutajad { get; set; }
        public DbSet<Sondmus> Sondmused { get; set; }
        public DbSet<Meeldetuletus> Meeldetuletused { get; set; }
    }
}
