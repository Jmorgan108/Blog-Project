using BlogSpot.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BlogSpot.Posts
{
    public class PostAppService : 
        CrudAppService<
            Post, //Post Entity
            PostDto, //Used to show Posts
            Guid, //Primary key of the post
            PagedAndSortedResultRequestDto,//Used for Paging and sorting  
            CreateUpdatePostsDto>, //Used to create update
        IPostAppService
    {



        public PostAppService(IRepository<Post, Guid> repository) 
            : base(repository)
        {
            GetPolicyName = BlogSpotPermissions.Posts.Default;
            GetListPolicyName = BlogSpotPermissions.Posts.Default;
            CreatePolicyName = BlogSpotPermissions.Posts.Create;
            UpdatePolicyName = BlogSpotPermissions.Posts.Edit;
            DeletePolicyName = BlogSpotPermissions.Posts.Delete;
        }
    }
}
