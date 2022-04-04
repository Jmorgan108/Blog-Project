using AutoMapper;
using BlogSpot.Posts;

namespace BlogSpot;

public class BlogSpotApplicationAutoMapperProfile : Profile
{
    public BlogSpotApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Post, PostDto>();
        CreateMap<CreateUpdatePostsDto, Post>();
    }
}
