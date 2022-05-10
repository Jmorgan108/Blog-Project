using AutoMapper;
using BlogSpot.Authors;
using BlogSpot.Posts;

namespace BlogSpot;

public class BlogSpotApplicationAutoMapperProfile : Profile
{
    public BlogSpotApplicationAutoMapperProfile()
    {
        
        CreateMap<Post, PostDto>();
        CreateMap<CreateUpdatePostsDto, Post>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();

    }
}
