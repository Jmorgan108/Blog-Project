using BlogSpot.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlogSpot.Permissions;

public class BlogSpotPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BlogSpotPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BlogSpotPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlogSpotResource>(name);
    }
}
