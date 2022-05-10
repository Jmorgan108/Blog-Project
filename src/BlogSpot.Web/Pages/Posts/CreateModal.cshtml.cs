using Microsoft.AspNetCore.Mvc;
using BlogSpot.Posts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using AutoMapper;

namespace BlogSpot.Web.Pages.Posts
{
    public class CreateModalModel : BlogSpotPageModel
    {
        [BindProperty]
        public CreatePostViewModel Post { get; set; }
        public List<SelectListItem> Authors { get; set; }

        private readonly IPostAppService _postAppService;

        public CreateModalModel(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        public async void OnGetAsync()
        {
            Post = new CreatePostViewModel();

            var authorLookup = await _postAppService.GetAuthorLookupAsync();
            Authors = authorLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _postAppService.CreateAsync(
                ObjectMapper.Map<CreatePostViewModel, CreateUpdatePostsDto>(Post)
                );
            return NoContent();
        }

        
    }  
}
