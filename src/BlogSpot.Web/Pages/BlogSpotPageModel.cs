using BlogSpot.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BlogSpot.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BlogSpotPageModel : AbpPageModel
{
    protected BlogSpotPageModel()
    {
        LocalizationResourceType = typeof(BlogSpotResource);
    }
}
