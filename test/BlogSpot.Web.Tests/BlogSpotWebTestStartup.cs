using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace BlogSpot;

public class BlogSpotWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<BlogSpotWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
