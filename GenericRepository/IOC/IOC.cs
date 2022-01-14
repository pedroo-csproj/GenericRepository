using GenericRepository.Implementations;
using GenericRepository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GenericRepository.IOC
{
    public static class IOC
    {
        public static void RegisterGenericRepository(this IServiceCollection services) =>
            services.AddTransient<IRepository, Repository>();
    }
}
