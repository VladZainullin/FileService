using Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

internal sealed class AppDbContext : DbContext
{
    private readonly IOptionsSnapshot<ConnectionStringsOptions> _connectionStringsOptions;

    public AppDbContext(IOptionsSnapshot<ConnectionStringsOptions> connectionStringsOptions)
    {
        _connectionStringsOptions = connectionStringsOptions;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionStringsOptions.Value.Postgres);

        base.OnConfiguring(optionsBuilder);
    }
}