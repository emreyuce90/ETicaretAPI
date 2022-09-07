using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistentService(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(option=>option.UseNpgsql(ConnectionstringHelper.ConnectionString));
        }
    }
}
