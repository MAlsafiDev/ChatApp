using ChatApp.Application.Behaviors;
using ChatApp.Application.Features.Messages.Commands.validator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
namespace ChatApp.Application
{
    public static class ModuleApplicationDependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services) 
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(typeof(AddMessageCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
