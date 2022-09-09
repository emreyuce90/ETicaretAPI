using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Commons;
using ETicaretAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool isTracked = true)
        {
            var query = Table.AsQueryable();
            if (!isTracked)
            {
                query = query.AsNoTracking();
            }
            await query.AnyAsync(expression);
            return true;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression, bool isTracked = true)
        {
            var query = Table.AsQueryable();
            if (!isTracked)
            {
                query = query.AsNoTracking();
            }
            return await query.CountAsync(expression);
        }

        public IQueryable<T> GetAll(bool isTracked = true)
        {
            var query = Table.AsQueryable();
            if (!isTracked)
            {
                query = query.AsNoTracking();
            }
            return query;
        }


        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, bool isTracked = true)
        {
            var query = Table.AsQueryable();
            if (!isTracked)
            {
                query = query.AsNoTracking();
            }
            return query.Where(expression);
        }

        public async Task<T> GetByIdAsync(string id, bool isTracked = true)
        {
            var query = Table.AsQueryable();
            if (!isTracked)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(t=>t.Id == Guid.Parse(id));
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracked = true)
        {
            var query = Table.AsQueryable();
            if (!isTracked)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(expression);
        }

    }
}
