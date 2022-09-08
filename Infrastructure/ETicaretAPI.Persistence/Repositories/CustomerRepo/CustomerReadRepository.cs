using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.CustomerRepo
{
    public class CustomerReadRepository:ReadRepository<Customer>
    {
        public CustomerReadRepository(ETicaretAPIDbContext context) : base(context)
        {

        }
    }
}
