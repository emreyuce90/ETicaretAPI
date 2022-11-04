using ETicaretAPI.Application.Services.Token;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}
