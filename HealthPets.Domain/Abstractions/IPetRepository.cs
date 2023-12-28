using HealthPets.Domain.Entities;

namespace HealthPets.Domain.Abstractions
{
    public interface IPetRepository : IBaseRepository<Pet>
    {
        Task<Pet> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}
