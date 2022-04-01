using BlogSpot.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BlogSpot.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BlogSpotController : AbpControllerBase
{
    protected BlogSpotController()
    {
        LocalizationResource = typeof(BlogSpotResource);
    }
}
