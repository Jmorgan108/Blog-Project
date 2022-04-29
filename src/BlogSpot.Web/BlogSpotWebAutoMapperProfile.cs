using AutoMapper;
using BlogSpot.Posts;

namespace BlogSpot.Web;

public class BlogSpotWebAutoMapperProfile : Profile
{
    public BlogSpotWebAutoMapperProfile()
    {
        CreateMap<PostDto, CreateUpdatePostsDto>();
        //Define your AutoMapper configuration here for the Web project.
    }
}
