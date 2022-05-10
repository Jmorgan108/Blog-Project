using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogSpot.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace BlogSpot.Web.Pages.Posts
{
    public class EditModalModel : BlogSpotPageModel
    {
        [BindProperty]
        public EditPostViewModel Post { get; set; }
        public List<SelectListItem> Authors { get; set; }

        [BindProperty]
        public Guid Id { get; set; }    

        private readonly IPostAppService _postAppService;

        public EditModalModel(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var postDto = await _postAppService.GetAsync(id);
            Post = ObjectMapper.Map<PostDto, EditPostViewModel>(postDto);
            Id = postDto.Id;

            var authorLookup = await _postAppService.GetAuthorLookupAsync();
            Authors = authorLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _postAppService.UpdateAsync(
                Id,
                ObjectMapper.Map<EditPostViewModel, CreateUpdatePostsDto>(Post)
            );

            return NoContent();
        } 
    }
}