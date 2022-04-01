using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlogSpot.Data;
using Volo.Abp.DependencyInjection;

namespace BlogSpot.EntityFrameworkCore;

public class EntityFrameworkCoreBlogSpotDbSchemaMigrator
    : IBlogSpotDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBlogSpotDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BlogSpotDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BlogSpotDbContext>()
            .Database
            .MigrateAsync();
    }
}
