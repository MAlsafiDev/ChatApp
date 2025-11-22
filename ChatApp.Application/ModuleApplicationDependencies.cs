using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ChatApp.Application
{
    public static class ModuleApplicationDependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services) 
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
