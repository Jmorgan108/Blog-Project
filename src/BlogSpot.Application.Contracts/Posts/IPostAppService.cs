using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace BlogSpot.Posts
{
    public interface IPostAppService : ICrudAppService<PostDto, Guid, 
        PagedAndSortedResultRequestDto, CreateUpdatePostsDto>
    {

    }
}
