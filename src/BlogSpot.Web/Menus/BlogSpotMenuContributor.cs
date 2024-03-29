﻿using System.Threading.Tasks;
using BlogSpot.Localization;
using BlogSpot.MultiTenancy;
using BlogSpot.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace BlogSpot.Web.Menus;

public class BlogSpotMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {

        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<BlogSpotResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BlogSpotMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );
        
        var blogSpotMenu = new ApplicationMenuItem(
            "BlogSpot",
            l["Menu:BlogSpot"],
            icon: "fa fa-blog"
        );

        context.Menu.AddItem(blogSpotMenu);
        
        if (await context.IsGrantedAsync(BlogSpotPermissions.Posts.Default))
        {
            blogSpotMenu.AddItem(new ApplicationMenuItem(
                "BlogSpot.Posts",
                l["Menu:Posts"],
                url: "/Posts"
                ));
        }

        if (await context.IsGrantedAsync(BlogSpotPermissions.Authors.Default))
        {
            blogSpotMenu.AddItem(new ApplicationMenuItem(
                "BlogSpot.Authors",
                l["Menu:Authors"],
                url: "/Authors"
            ));
        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
