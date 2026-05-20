
using ChatApp.Application.Interfaces.IUnitOfWork;
using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Infrastrucure.Context;
using ChatApp.Infrastrucure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChatApp.Infrastrucure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ChatAppDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
