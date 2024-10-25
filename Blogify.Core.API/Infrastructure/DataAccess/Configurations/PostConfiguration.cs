using Blogify.Core.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogify.Core.API.Infrastructure.DataAccess.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(x => x.Heading).HasMaxLength(128);
        builder.Property(x => x.ShortDescription).HasMaxLength(1024);
        builder.Property(x => x.ImageUrl).HasMaxLength(256);
    }
}
