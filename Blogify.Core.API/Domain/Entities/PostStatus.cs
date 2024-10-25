using Blogify.Core.API.Domain.Enums;

namespace Blogify.Core.API.Domain.Entities;

public class PostStatus
{
    public int Id { get; set; }
    public PostStatusEnum Status { get; set; }
    public int PostId { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public Post Post { get; set; }
}
