using AutoMapper;
using BlogSpot.Authors;
using BlogSpot.Posts;

namespace BlogSpot.Web;

public class BlogSpotWebAutoMapperProfile : Profile
{
    public BlogSpotWebAutoMapperProfile()
    {
        CreateMap<PostDto, CreateUpdatePostsDto>();
        CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel,
                      CreateAuthorDto>();
        CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
        CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel,
                  UpdateAuthorDto>();
    }
}
