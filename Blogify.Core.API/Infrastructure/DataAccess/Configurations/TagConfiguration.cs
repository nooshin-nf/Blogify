using Blogify.Core.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogify.Core.API.Infrastructure.DataAccess.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.DisplayName).HasMaxLength(50);

        builder.HasIndex(x => x.Name).IsUnique(true);
        builder.HasIndex(x => x.DisplayName).IsUnique(true);

    }
}
