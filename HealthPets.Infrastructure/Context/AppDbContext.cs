using HealthPets.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthPets.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        
        public DbSet<Pet> Pets { get; set; }
    }
}
