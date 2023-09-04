using System.Reflection;
using Infrastructure.Options;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

internal sealed class AppDbContext : DbContext
{
    private readonly IOptionsSnapshot<ConnectionStringsOptions> _connectionStringsOptions;
    private readonly RootFolderConfiguration _rootFolderConfiguration;

    public AppDbContext(
        RootFolderConfiguration rootFolderConfiguration,
        IOptionsSnapshot<ConnectionStringsOptions> connectionStringsOptions)
    {
        _rootFolderConfiguration = rootFolderConfiguration;
        _connectionStringsOptions = connectionStringsOptions;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableDetailedErrors().UseNpgsql(_connectionStringsOptions.Value.Postgres);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(_rootFolderConfiguration);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}