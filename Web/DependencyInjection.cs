using Web.Middlewares;

namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        return services
            .ConfigureMiddlewares()
            .ConfigureControllers()
            .ConfigureSwagger();
    }

    private static IServiceCollection ConfigureMiddlewares(this IServiceCollection services)
    {
        return services.AddScoped<TransactionMiddleware>();
    }

    private static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        return services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
    }
}