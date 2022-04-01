using System;
using System.Collections.Generic;
using System.Text;
using BlogSpot.Localization;
using Volo.Abp.Application.Services;

namespace BlogSpot;

/* Inherit your application services from this class.
 */
public abstract class BlogSpotAppService : ApplicationService
{
    protected BlogSpotAppService()
    {
        LocalizationResource = typeof(BlogSpotResource);
    }
}
