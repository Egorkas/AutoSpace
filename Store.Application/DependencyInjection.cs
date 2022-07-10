using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Common.Behaviors;
using System.Reflection;

namespace Store.Application
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
