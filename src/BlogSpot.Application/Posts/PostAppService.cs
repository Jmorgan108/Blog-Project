using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BlogSpot.Posts
{
    public class PostAppService : CrudAppService<Post, PostDto, Guid, 
        PagedAndSortedResultRequestDto, CreateUpdatePostsDto>, IPostsAppService
    {
        public PostAppService(IRepository<Post, Guid> repository) : base(repository)
        {

        }
    }
}
