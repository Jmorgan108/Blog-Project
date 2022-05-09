
using Volo.Abp.Application.Dtos;

namespace BlogSpot.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
