using Blogify.Common;
using Blogify.Common.ApiQuery;
using Blogify.Core.API.Controllers.Dtos;
using Blogify.Core.API.IServies;
using Microsoft.AspNetCore.Mvc;

namespace Blogify.Core.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<ApiResponseModel<GetTagsResponseDto>> Get([FromQuery] QueryOptions<GetTagsRequestDto> query) =>
            new ApiResponseModel<GetTagsResponseDto>(await _tagService.GetTagsByFilterAsync(query));

        [HttpPost]
        public async Task<ApiResponseModel<AddResponseDto>> Add(AddTagRequestDto request) =>
           new ApiResponseModel<AddResponseDto>(await _tagService.AddTag(request));
    }
}
