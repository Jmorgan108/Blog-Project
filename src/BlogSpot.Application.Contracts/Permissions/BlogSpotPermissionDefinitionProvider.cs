using BlogSpot.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlogSpot.Permissions;

public class BlogSpotPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var blogSpotGroup = context.AddGroup(BlogSpotPermissions.GroupName, L("Permission:BlogSpot"));

        var postsPermission = blogSpotGroup.AddPermission(BlogSpotPermissions.Posts.Default, L("Permission:Posts"));
        postsPermission.AddChild(BlogSpotPermissions.Posts.Create, L("Permission:Posts.Create"));
        postsPermission.AddChild(BlogSpotPermissions.Posts.Edit, L("Permission:Posts.Edit"));
        postsPermission.AddChild(BlogSpotPermissions.Posts.Delete, L("Permission:Posts.Delete"));

        //Define your own permissions here.Example:
        //myGroup.AddPermission(BlogSpotPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlogSpotResource>(name);
    }
}
