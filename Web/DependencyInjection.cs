namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        return services
            .ConfigureControllers()
            .ConfigureSwagger();
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