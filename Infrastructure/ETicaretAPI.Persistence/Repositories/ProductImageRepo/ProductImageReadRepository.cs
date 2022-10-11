using ETicaretAPI.Application.Repositories.ProductImageRepo;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;

namespace ETicaretAPI.Persistence.Repositories.ProductImageRepo
{
    public class ProductImageReadRepository : ReadRepository<ProductImages>,IProductImageReadRepository
    {
        public ProductImageReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
