using Blogify.Core.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Core.API.Domain;

public interface IBlogifyDbContext
{
    public DbSet<Follower> Followers { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostStatus> PostStatus { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
