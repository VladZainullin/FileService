using Domain.Entities;
using Domain.Enums;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

file sealed class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.HasDiscriminator(nameof(Resource.TypeId), typeof(ResourceType))
            .HasValue(typeof(RootFolder), ResourceType.RootFolder)
            .HasValue(typeof(Folder), ResourceType.Folder)
            .HasValue(typeof(Document), ResourceType.Document);
    }
}