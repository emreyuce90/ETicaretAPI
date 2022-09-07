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

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            await Table.AnyAsync(expression);
            return true;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.CountAsync(expression);
        }

        public IQueryable<T> GetAll() => Table;


        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression) => Table.Where(expression);


        public async Task<T> GetByIdAsync(string id) => await Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id));


        public async Task<T> GetAsync(Expression<Func<T, bool>> expression) => await Table.FirstOrDefaultAsync(expression);
    
    }
}
