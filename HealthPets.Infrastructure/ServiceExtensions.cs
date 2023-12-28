using HealthPets.Domain.Abstractions;
using HealthPets.Infrastructure.Context;
using HealthPets.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthPets.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                           options.UseSqlite(connectionString));

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
