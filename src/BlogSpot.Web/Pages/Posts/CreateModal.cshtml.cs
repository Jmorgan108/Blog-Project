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

        private readonly IPostsAppService _postAppService;

        public CreateModalModel(IPostsAppService postAppService)
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
