using HealthPets.Domain.Abstractions;
using HealthPets.Domain.Entities;
using HealthPets.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthPets.Infrastructure.Repositories
{
    public class PetRepository : BaseRepository<Pet>, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context) { }

        public async Task<Pet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
            return pet ?? throw new Exception("Pet not found");
        }

    }
}
