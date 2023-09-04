using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

internal sealed class RootFolderConfiguration : IEntityTypeConfiguration<RootFolder>
{
    private readonly RootFolder _folder;

    public RootFolderConfiguration(RootFolder folder)
    {
        _folder = folder;
    }

    public void Configure(EntityTypeBuilder<RootFolder> builder)
    {
        builder.HasData(_folder);
    }
}