namespace Blogify.Core.API.Controllers.Dtos;

public class GetPostsRequestDto
{
    public string Heading { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public DateTime? PublishDate { get; set; }
    public int AuthorUserId { get; set; }

}
