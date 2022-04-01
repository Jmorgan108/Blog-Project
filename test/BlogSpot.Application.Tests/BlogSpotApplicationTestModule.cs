using Volo.Abp.Modularity;

namespace BlogSpot;

[DependsOn(
    typeof(BlogSpotApplicationModule),
    typeof(BlogSpotDomainTestModule)
    )]
public class BlogSpotApplicationTestModule : AbpModule
{

}
