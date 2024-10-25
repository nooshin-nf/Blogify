using AutoMapper;
using Blogify.Common.ApiQuery;
using Blogify.Core.API.Controllers.Dtos;
using Blogify.Core.API.Domain.Entities;
using Blogify.Core.API.IServies;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Core.API.Domain.Services;

public class PostService(IBlogifyDbContext context,
    IMapper mapper) : IPostService
{
    private readonly IBlogifyDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<GetPostsResponseDto> GetPostsByFilterAsync(QueryOptions<GetPostsRequestDto> query)
    {
        var posts = _context.Posts;
        return new GetPostsResponseDto
        {
            Posts = await _mapper.ProjectTo<GetPostResponseDto>(posts).ToListAsync(),
            TotalCount = posts.Count()
        };
    }

    public async Task<AddResponseDto> AddPost(AddPostRequestDto request)
    {
        var post = _mapper.Map<Post>(request);
        post.PendPostStatus();
        post.AddPostTags(request.TagIds);
        await _context.Posts.AddAsync(post);

        await _context.SaveChangesAsync();
        return new AddResponseDto
        {
            Id = post.Id
        };
    }
}
