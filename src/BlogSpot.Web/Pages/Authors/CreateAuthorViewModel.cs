using BlogSpot.Authors;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace BlogSpot.Web.Pages.Authors
{
    public class CreateAuthorViewModel
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [TextArea]
        public string ShortBio { get; set; }
    }
}
