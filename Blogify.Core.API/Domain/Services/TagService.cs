using AutoMapper;
using Blogify.Common.ApiQuery;
using Blogify.Core.API.Controllers.Dtos;
using Blogify.Core.API.Domain.Entities;
using Blogify.Core.API.IServies;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Core.API.Domain.Services;

public class TagService(IBlogifyDbContext context,
    IMapper mapper) : ITagService
{
    private readonly IBlogifyDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<GetTagsResponseDto> GetTagsByFilterAsync(QueryOptions<GetTagsRequestDto> query)
    {
        var tags = _context.Tags;
        return new GetTagsResponseDto
        {
            Tags = await _mapper.ProjectTo<GetTagResponseDto>(tags).ToListAsync(),
            TotalCount = tags.Count()
        };
    }

    public async Task<AddResponseDto> AddTag(AddTagRequestDto request)
    {
        var tag = _mapper.Map<Tag>(request);

        await _context.Tags.AddAsync(tag);
        await _context.SaveChangesAsync();

        return new AddResponseDto
        {
            Id = tag.Id
        };
    }
}
