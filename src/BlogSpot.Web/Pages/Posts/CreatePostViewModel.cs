using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace BlogSpot.Web.Pages.Posts
{
    public class CreatePostViewModel
    {
        [SelectItems(nameof(Authors))]
        [DisplayName("Author")]
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public TagType Type { get; set; } = TagType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

    }
}
