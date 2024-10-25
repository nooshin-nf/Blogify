using AutoMapper;
using Blogify.Core.API.Controllers.Dtos;
using Blogify.Core.API.Domain.Entities;

namespace Blogify.Core.API;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Post, GetPostResponseDto>();
        CreateMap<AddPostRequestDto, Post>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now));

        CreateMap<Tag, GetTagResponseDto>();
        CreateMap<AddTagRequestDto, Tag>();
    }
}
