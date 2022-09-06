using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetAll()
        {
            var products = new List<Product>()
            {
                new(){Id =Guid.NewGuid(),CreatedDate=DateTime.Now,IsActive=true,IsDeleted =false,Name="Product 1",Price=300,Stock=100},
                new(){Id =Guid.NewGuid(),CreatedDate=DateTime.Now,IsActive=true,IsDeleted =false,Name="Product 2",Price=400,Stock=200},
                new(){Id =Guid.NewGuid(),CreatedDate=DateTime.Now,IsActive=true,IsDeleted =false,Name="Product 3",Price=500,Stock=300},
                new(){Id =Guid.NewGuid(),CreatedDate=DateTime.Now,IsActive=true,IsDeleted =false,Name="Product 4",Price=600,Stock=400},
                new(){Id =Guid.NewGuid(),CreatedDate=DateTime.Now,IsActive=true,IsDeleted =false,Name="Product 5",Price=700,Stock=500},
                new(){Id =Guid.NewGuid(),CreatedDate=DateTime.Now,IsActive=true,IsDeleted =false,Name="Product 6",Price=800,Stock=600},
                new(){Id =Guid.NewGuid(),CreatedDate=DateTime.Now,IsActive=true,IsDeleted =false,Name="Product 7",Price=900,Stock=700},
            };

            return products;
        }
    }
}
