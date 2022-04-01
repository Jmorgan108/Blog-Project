using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace BlogSpot.Web;

[Dependency(ReplaceServices = true)]
public class BlogSpotBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BlogSpot";
}
