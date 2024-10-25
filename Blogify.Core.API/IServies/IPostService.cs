using Blogify.Common.ApiQuery;
using Blogify.Core.API.Controllers.Dtos;

namespace Blogify.Core.API.IServies
{
    public interface IPostService
    {
        Task<GetPostsResponseDto> GetPostsByFilterAsync(QueryOptions<GetPostsRequestDto> query);
        Task<AddResponseDto> AddPost(AddPostRequestDto request);
    }
}
