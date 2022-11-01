using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories.ProductRepo;
using ETicaretAPI.Persistence.Repositories.ProductRepo;
using ETicaretAPI.Application.Repositories.CustomerRepo;
using ETicaretAPI.Persistence.Repositories.CustomerRepo;
using ETicaretAPI.Application.Repositories.OrderRepo;
using ETicaretAPI.Persistence.Repositories.OrderRepo;
using ETicaretAPI.Application.Repositories.FileRepo;
using ETicaretAPI.Persistence.Repositories.FileRepo;
using ETicaretAPI.Application.Repositories.ProductImageRepo;
using ETicaretAPI.Persistence.Repositories.ProductImageRepo;
using ETicaretAPI.Application.Repositories.InvoiceRepo;
using ETicaretAPI.Persistence.Repositories.InvoiceRepo;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistentService(this IServiceCollection services)
        {
            //services.AddDbContext<ETicaretAPIDbContext>(option=>option.UseNpgsql(ConnectionstringHelper.PostgreString));
            services.AddDbContext<ETicaretAPIDbContext>(opt=>opt.UseSqlServer(ConnectionstringHelper.MssqlString));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ETicaretAPIDbContext>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IFileReadReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IProductImageWriteRepo, ProductImageWriteRepository>();
            services.AddScoped<IProductImageReadRepository, ProductImageReadRepository>();
            services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();
            services.AddScoped<IInvoiceReadRepository, InvoiceReadRepository>();
        }
    }
}
