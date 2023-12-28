using HealthPets.Domain.Abstractions;
using HealthPets.Domain.Entities;
using HealthPets.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthPets.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            entity.CreatedDate = DateTimeOffset.UtcNow;
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTimeOffset.UtcNow;
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletedDate = DateTimeOffset.UtcNow;
            _context.Remove(entity);
        }


        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
           return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(Ulid id, CancellationToken cancellationToken)
        {
            var pet = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return pet?? throw new Exception("Pet not found");
        }

        
    }
}
