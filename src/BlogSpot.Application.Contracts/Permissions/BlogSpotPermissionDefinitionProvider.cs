using BlogSpot.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlogSpot.Permissions;

public class BlogSpotPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var blogSpotGroup = context.AddGroup(BlogSpotPermissions.GroupName, L("Permission:BlogSpot"));

        var postsPermission = blogSpotGroup.AddPermission(
            BlogSpotPermissions.Posts.Default, L("Permission:Posts"));
        postsPermission.AddChild(
            BlogSpotPermissions.Posts.Create, L("Permission:Posts.Create"));
        postsPermission.AddChild(
            BlogSpotPermissions.Posts.Edit, L("Permission:Posts.Edit"));
        postsPermission.AddChild(
            BlogSpotPermissions.Posts.Delete, L("Permission:Posts.Delete"));

        var authorsPermission = blogSpotGroup.AddPermission(
            BlogSpotPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(
            BlogSpotPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(
            BlogSpotPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(
            BlogSpotPermissions.Authors.Delete, L("Permission:Authors.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlogSpotResource>(name);
    }
}
