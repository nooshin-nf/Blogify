using Blogify.Core.API.Domain;
using Blogify.Core.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Blogify.Core.API.Infrastructure.DataAccess;

public class BlogifyDbContext(DbContextOptions options) : DbContext(options), IBlogifyDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Follower> Followers { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostStatus> PostStatus { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
