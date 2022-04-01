using BlogSpot.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BlogSpot;

[DependsOn(
    typeof(BlogSpotEntityFrameworkCoreTestModule)
    )]
public class BlogSpotDomainTestModule : AbpModule
{

}
