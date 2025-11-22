using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ChatApp.Application
{
    public static class ModuleApplicationDependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services) 
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //services.AddValidatorsFromAssembly(typeof(AddStudentCommandValidator).Assembly);
            return services;
        }
    }
}
