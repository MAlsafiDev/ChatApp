using ChatApp.Infrastructure.InfrastructureBases;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastrucure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            return services;
        }
    }
}
