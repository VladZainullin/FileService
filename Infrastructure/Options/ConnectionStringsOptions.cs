namespace Infrastructure.Options;

internal sealed class ConnectionStringsOptions
{
    public required string Postgres { get; init; }
}