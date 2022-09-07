using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Commons;
using ETicaretAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry=await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;

        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var deleted = await Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(Id));
            EntityEntry entityEntry = Table.Remove(deleted);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            EntityEntry entityEntry= Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
