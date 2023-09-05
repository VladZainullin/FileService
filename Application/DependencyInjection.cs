using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services.ConfigureMediatR();
    }

    private static IServiceCollection ConfigureMediatR(this IServiceCollection services)
    {
        return services.AddMediatR(o =>
        {
            o.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}