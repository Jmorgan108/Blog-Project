using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace BlogSpot.Pages;

public class Index_Tests : BlogSpotWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
