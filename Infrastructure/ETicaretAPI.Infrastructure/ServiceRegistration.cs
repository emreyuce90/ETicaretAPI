using ETicaretAPI.Application.Services.Storages;
using ETicaretAPI.Application.Services.Token;
using ETicaretAPI.Infrastructure.Enums;
using ETicaretAPI.Infrastructure.Services.Storages;
using ETicaretAPI.Infrastructure.Services.Storages.Azure;
using ETicaretAPI.Infrastructure.Services.Storages.Local;
using ETicaretAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfraStructureService(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<ITokenCreate, TokenCreate>();

        }

        public static void AddStorage<T>(this IServiceCollection services) where T:Storage,IStorage
        {
            services.AddScoped<IStorage, T>();
        }

        //public static void AddStorage(this IServiceCollection services, StorageType storageType)
        //{
        //    switch (storageType)
        //    {
        //        case StorageType.Local:
        //            services.AddScoped<IStorage, LocalStorage>();
        //            break;
        //        case StorageType.AWS:
        //            services.AddScoped<IStorage, LocalStorage>();

        //            break;
        //        case StorageType.Azure:
        //            services.AddScoped<IStorage, AzureStorage>();

        //            break;
        //        default:
        //            services.AddScoped<IStorage, LocalStorage>();
        //            break;
        //    }
        //}
    }
}
