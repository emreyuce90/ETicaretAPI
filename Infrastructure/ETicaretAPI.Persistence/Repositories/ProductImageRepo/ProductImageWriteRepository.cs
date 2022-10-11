using ETicaretAPI.Application.Repositories.ProductImageRepo;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;

namespace ETicaretAPI.Persistence.Repositories.ProductImageRepo
{
    public class ProductImageWriteRepository : WriteRepository<ProductImages>, IProductImageWriteRepo
    {
        public ProductImageWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
