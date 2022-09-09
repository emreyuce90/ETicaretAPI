using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Context
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions<ETicaretAPIDbContext> options) : base(options)
        {

        }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //interceptor
            var interceptorDatas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in interceptorDatas)
            {
                if (data.State == EntityState.Modified)
                {
                    data.Entity.ModifiedDate = DateTime.UtcNow;
                }
                else if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.UtcNow;
                    data.Entity.IsDeleted = false;
                    data.Entity.IsActive = false;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
