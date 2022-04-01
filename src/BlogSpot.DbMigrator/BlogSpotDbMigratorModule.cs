using BlogSpot.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BlogSpot.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BlogSpotEntityFrameworkCoreModule),
    typeof(BlogSpotApplicationContractsModule)
    )]
public class BlogSpotDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
