using ETicaretAPI.Application.Repositories.InvoiceRepo;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;

namespace ETicaretAPI.Persistence.Repositories.InvoiceRepo
{
    public class InvoiceReadRepository : ReadRepository<Invoice>,IInvoiceReadRepository
    {
        public InvoiceReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
