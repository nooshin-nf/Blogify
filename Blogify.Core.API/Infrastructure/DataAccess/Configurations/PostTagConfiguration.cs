using Blogify.Core.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogify.Core.API.Infrastructure.DataAccess.Configurations;

public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
{
    public void Configure(EntityTypeBuilder<PostTag> builder)
    {
        builder.HasOne(x => x.Post).WithMany(x => x.PostTags).HasForeignKey(x => x.PostId);
        builder.HasOne(x => x.Tag).WithMany(x => x.PostTags).HasForeignKey(x => x.TagId);

        builder.HasIndex(x => new { x.PostId, x.TagId }).IsUnique(true);


    }
}
