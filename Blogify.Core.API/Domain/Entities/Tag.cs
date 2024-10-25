namespace Blogify.Core.API.Domain.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }

    public ICollection<PostTag> PostTags { get; set; }
}
