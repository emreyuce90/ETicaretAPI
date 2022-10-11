using ETicaretAPI.Application.Repositories.InvoiceRepo;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;

namespace ETicaretAPI.Persistence.Repositories.InvoiceRepo
{
    public class InvoiceWriteRepository : WriteRepository<Invoice>,IInvoiceWriteRepository
    {
        public InvoiceWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
