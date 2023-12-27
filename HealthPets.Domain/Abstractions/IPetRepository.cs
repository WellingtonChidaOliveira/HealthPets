using HealthPets.Domain.Entities;

namespace HealthPets.Domain.Abstractions
{
    public interface IPetRepository : IBaseRepository<Pets>
    {
        Task<Pets> GetByNameAsync(string name);
    }
}
