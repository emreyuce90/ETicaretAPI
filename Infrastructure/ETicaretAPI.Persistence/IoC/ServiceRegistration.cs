using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddPersistentService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
