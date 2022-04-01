using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BlogSpot.Data;

/* This is used if database provider does't define
 * IBlogSpotDbSchemaMigrator implementation.
 */
public class NullBlogSpotDbSchemaMigrator : IBlogSpotDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
