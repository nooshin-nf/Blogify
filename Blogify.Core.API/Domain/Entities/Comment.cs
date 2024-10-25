namespace Blogify.Core.API.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public Comment? Parent { get; set; }
    public Post Post { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
