using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace BlogSpot.Web.Pages.Posts
{
    public class EditPostViewModel
    {
        [HiddenInput]
        public Guid UserId { get; set; }

        [SelectItems(nameof(Authors))]
        [DisplayName("Author")]
        public Guid AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [TextArea]
        public string Content { get; set; }

        public TagType Tags { get; set; } = TagType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

    }
}
