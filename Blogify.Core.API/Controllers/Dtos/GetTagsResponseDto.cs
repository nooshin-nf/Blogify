namespace Blogify.Core.API.Controllers.Dtos;

public class GetTagsResponseDto
{
    public List<GetTagResponseDto> Tags { get; set; }
    public int TotalCount { get; set; }
}

public class GetTagResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
}
