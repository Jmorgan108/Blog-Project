using AutoMapper;
using BlogSpot.Authors;
using BlogSpot.Posts;

namespace BlogSpot.Web;

public class BlogSpotWebAutoMapperProfile : Profile
{
    public BlogSpotWebAutoMapperProfile()
    {
        CreateMap<PostDto, CreateUpdatePostsDto>();
        CreateMap<Pages.Authors.CreateAuthorViewModel,CreateAuthorDto>();
        CreateMap<AuthorDto, Pages.Authors.EditAuthorViewModel>();
        CreateMap<Pages.Authors.EditAuthorViewModel,UpdateAuthorDto>();
        CreateMap<Pages.Posts.CreatePostViewModel, CreateUpdatePostsDto>();
        CreateMap<PostDto, Pages.Posts.EditPostViewModel>();
        CreateMap<Pages.Posts.EditPostViewModel, CreateUpdatePostsDto>();
        CreateMap<Pages.Posts.CreatePostViewModel, CreateUpdatePostsDto>();
    }
}
