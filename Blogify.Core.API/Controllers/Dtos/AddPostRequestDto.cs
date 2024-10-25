namespace Blogify.Core.API.Controllers.Dtos
{
    public class AddPostRequestDto
    {
        public List<int> TagIds { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public int AuthorUserId { get; set; }
    }
}
