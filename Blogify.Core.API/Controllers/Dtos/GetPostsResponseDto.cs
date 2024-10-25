using Blogify.Core.API.Domain.Enums;

namespace Blogify.Core.API.Controllers.Dtos;

public class GetPostsResponseDto
{
    public List<GetPostResponseDto> Posts { get; set; }
    public int TotalCount { get; set; }
}

public class GetPostResponseDto
{
    public int Id { get; set; }
    public string Heading { get; set; }
    public string Title { get; set; }
    public DateTime? PublishDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AuthorUserId { get; set; }
    public PostStatusEnum Status { get; set; }
}
