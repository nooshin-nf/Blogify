using Blogify.Common;
using Blogify.Common.ApiQuery;
using Blogify.Core.API.Controllers.Dtos;
using Blogify.Core.API.IServies;
using Microsoft.AspNetCore.Mvc;

namespace Blogify.Core.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ApiResponseModel<GetPostsResponseDto>> Get([FromQuery] QueryOptions<GetPostsRequestDto> query) =>
            new ApiResponseModel<GetPostsResponseDto>(await _postService.GetPostsByFilterAsync(query));

        [HttpPost]
        public async Task<ApiResponseModel<AddResponseDto>> Add(AddPostRequestDto request) =>
           new ApiResponseModel<AddResponseDto>(await _postService.AddPost(request));
    }
}
