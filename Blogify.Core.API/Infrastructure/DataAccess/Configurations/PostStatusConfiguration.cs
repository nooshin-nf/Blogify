using Blogify.Core.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogify.Core.API.Infrastructure.DataAccess.Configurations;

public class PostStatusConfiguration : IEntityTypeConfiguration<PostStatus>
{
    public void Configure(EntityTypeBuilder<PostStatus> builder)
    {
        builder.HasOne(x => x.Post).WithOne(x => x.PostStatus)
            .HasForeignKey<PostStatus>(x => x.PostId).IsRequired();
    }
}
