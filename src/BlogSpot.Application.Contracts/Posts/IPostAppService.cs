using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using BlogSpot.Authors;

namespace BlogSpot.Posts
{
    public interface IPostAppService : 
        ICrudAppService<PostDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdatePostsDto>
    {
        Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
    }
}
