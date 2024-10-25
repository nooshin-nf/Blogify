namespace Blogify.Core.API.Domain.Entities;

public class Follower
{
    public int Id { get; set; }
    public int FollowerUserId { get; set; }
    public int FollowingUserId { get; set; }
}
