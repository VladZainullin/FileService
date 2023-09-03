using Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services.ConfigureOptions(configuration);
    }

    private static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<ConnectionStringsOptions>(nameof(ConnectionStringsOptions))
            .Configure(a => configuration.GetSection(nameof(ConnectionStringsOptions)));

        return services;
    }
}