using FluentValidation;
using HoloCart.Core.Behaviour;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HoloCart.Core
{
    public static class ModuleCoreDebendancies
    {
        public static IServiceCollection AddCoreDebendancies(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;

        }
    }
}
