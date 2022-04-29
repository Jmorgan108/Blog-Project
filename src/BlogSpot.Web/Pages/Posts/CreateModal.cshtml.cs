using Microsoft.AspNetCore.Mvc;
using BlogSpot.Posts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogSpot.Web.Pages.Posts
{
    public class CreateModalModel : BlogSpotPageModel
    {
        [BindProperty]
        public CreateUpdatePostsDto Post { get; set; }

        private readonly IPostAppService _postAppService;

        public CreateModalModel(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        public void OnGet()
        {
            Post = new CreateUpdatePostsDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _postAppService.CreateAsync(Post);
            return NoContent();
        }
    }
}
