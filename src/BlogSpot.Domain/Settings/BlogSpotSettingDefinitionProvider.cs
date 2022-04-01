using Volo.Abp.Settings;

namespace BlogSpot.Settings;

public class BlogSpotSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BlogSpotSettings.MySetting1));
    }
}
