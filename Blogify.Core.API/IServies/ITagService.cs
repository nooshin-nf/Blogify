using Blogify.Common.ApiQuery;
using Blogify.Core.API.Controllers.Dtos;

namespace Blogify.Core.API.IServies
{
    public interface ITagService
    {
        Task<GetTagsResponseDto> GetTagsByFilterAsync(QueryOptions<GetTagsRequestDto> query);
        Task<AddResponseDto> AddTag(AddTagRequestDto request);
    }
}
