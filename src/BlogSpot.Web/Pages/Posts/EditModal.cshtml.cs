using System;
using System.Threading.Tasks;
using BlogSpot.Posts;
using Microsoft.AspNetCore.Mvc;

namespace BlogSpot.Web.Pages.Posts
{
    public class EditModalModel : BlogSpotPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdatePostsDto Post { get; set; }

        private readonly IPostAppService _postAppService;

        public EditModalModel(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        public async Task OnGetAsync()
        {
            var postDto = await _postAppService.GetAsync(Id);
            Post = ObjectMapper.Map<PostDto, CreateUpdatePostsDto>(postDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _postAppService.UpdateAsync(Id, Post);
            return NoContent();
        }
    }
}