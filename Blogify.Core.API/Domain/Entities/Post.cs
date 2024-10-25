using Blogify.Core.API.Domain.Enums;

namespace Blogify.Core.API.Domain.Entities;

public class Post
{
    public int Id { get; set; }
    public string Heading { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public string ImageUrl { get; set; }
    public DateTime? PublishDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int AuthorUserId { get; set; }
    public PostStatus PostStatus { get; set; }
    public ICollection<PostTag> PostTags { get; set; }
    public ICollection<Comment> Comments { get; set; }

    public void PendPostStatus()
    {
        PostStatus = new PostStatus()
        {
            PostId = Id,
            CreatedDate = DateTime.Now,
            Status = PostStatusEnum.Pending,
            UpdatedBy = AuthorUserId
        };
    }

    public void UpdatePostStatus(PostStatusEnum status,
        int updatedBy)
    {
        PostStatus.Status = status;
        PostStatus.UpdatedDate = DateTime.Now;
        PostStatus.UpdatedBy = updatedBy;
        if (status == PostStatusEnum.Confirmed)
            PublishDate = DateTime.Now;
    }

    public void AddPostTags(List<int> tagIds)
    {
        tagIds.ForEach(tagId =>
        {
            PostTags.Add(new PostTag() { PostId = Id, TagId = tagId });
        });
    }
}
