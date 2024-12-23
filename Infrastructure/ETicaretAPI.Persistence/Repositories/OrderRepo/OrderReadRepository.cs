﻿using ETicaretAPI.Application.Repositories.OrderRepo;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.OrderRepo
{
    public class OrderReadRepository : ReadRepository<Order>,IOrderReadRepository
    {
        public OrderReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
