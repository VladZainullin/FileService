using Application.Common.Interfaces;
using Infrastructure.Entities;
using Infrastructure.Options;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .ConfigureOptions(configuration)
            .ConfigureRootFolder()
            .ConfigureDbContext();
    }

    private static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringsOptions>(options =>
            configuration.GetSection(nameof(ConnectionStringsOptions)).Bind(options));
        services.Configure<RootFolderOptions>(options =>
            configuration.GetSection(nameof(RootFolderOptions)).Bind(options));

        return services;
    }

    private static IServiceCollection ConfigureRootFolder(this IServiceCollection services)
    {
        services.AddTransient<RootFolder>(
            s =>
            {
                var rootFolderOptions = s.GetRequiredService<IOptionsSnapshot<RootFolderOptions>>();

                return RootFolder.CreateInstance(rootFolderOptions.Value);
            });

        return services;
    }

    private static IServiceCollection ConfigureDbContext(this IServiceCollection services)
    {
        services.AddTransient<RootFolderConfiguration>();
        services.AddDbContext<AppDbContext>();

        services.AddScoped<IAppDbContext>(s => s.GetRequiredService<AppDbContext>());

        return services;
    }
}