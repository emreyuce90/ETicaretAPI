﻿using ETicaretAPI.Application.Repositories.ProductRepo;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.ProductRepo
{
    public class ProductReadRepository : ReadRepository<Product>,IProductReadRepository
    {
        public ProductReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
