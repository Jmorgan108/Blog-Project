using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace BlogSpot.Posts
{
    public interface IPostsAppService : ICrudAppService<PostDto, Guid, 
        PagedAndSortedResultRequestDto, CreateUpdatePostsDto>
    {

    }
}
