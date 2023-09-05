using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Options;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

internal sealed class AppDbContext : DbContext, IAppDbContext, ITransactionExecutor
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

    public DbSet<Resource> Resources => Set<Resource>();
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return Database.BeginTransactionAsync(cancellationToken);
    }
}