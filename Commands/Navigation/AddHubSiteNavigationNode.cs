using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Enums;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Utilities;

namespace SharePointPnP.PowerShell.Commands.Branding
{
    [Cmdlet(VerbsCommon.Add, "PnPHubSiteNavigationNode")]
    [CmdletHelp("Adds an item to a navigation element",
        "Adds a menu item to either the quicklaunch or top navigation",
        OutputType = typeof(NavigationNode),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.NavigationNode.aspx",
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
        Code = @"PS:> Add-PnPNavigationNode -Title ""Contoso"" -Url ""http://contoso.sharepoint.com/sites/contoso/"" -Location ""QuickLaunch""",
        Remarks = @"Adds a navigation node to the quicklaunch. The navigation node will have the title ""Contoso"" and will link to the url ""http://contoso.sharepoint.com/sites/contoso/""",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Add-PnPNavigationNode -Title ""Contoso USA"" -Url ""http://contoso.sharepoint.com/sites/contoso/usa/"" -Location ""QuickLaunch"" -Header ""Contoso""",
        Remarks = @"Adds a navigation node to the quicklaunch. The navigation node will have the title ""Contoso USA"", will link to the url ""http://contoso.sharepoint.com/sites/contoso/usa/"" and will have ""Contoso"" as a parent navigation node.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Add-PnPNavigationNode -Title ""Contoso"" -Url ""http://contoso.sharepoint.com/sites/contoso/"" -Location ""QuickLaunch"" -First",
        Remarks = @"Adds a navigation node to the quicklaunch, as the first item. The navigation node will have the title ""Contoso"" and will link to the url ""http://contoso.sharepoint.com/sites/contoso/""",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Add-PnPNavigationNode -Title ""Contoso Pharmaceuticals"" -Url ""http://contoso.sharepoint.com/sites/contosopharma/"" -Location ""QuickLaunch"" -External",
        Remarks = @"Adds a navigation node to the quicklaunch. The navigation node will have the title ""Contoso Pharmaceuticals"" and will link to the external url ""http://contoso.sharepoint.com/sites/contosopharma/""",
        SortOrder = 4)]
    [CmdletExample(
        Code = @"PS:> Add-PnPNavigationNode -Title ""Wiki"" -Location ""QuickLaunch"" -Url ""wiki/""",
        Remarks = @"Adds a navigation node to the quicklaunch. The navigation node will have the title ""Wiki"" and will link to Wiki library on the selected Web.",
        SortOrder = 5)]
    public class AddHubSiteNavigationNode : PnPWebCmdlet
    {
        [Parameter(Mandatory = false,HelpMessage="The key of the parent. Leave empty to add to the top level")]
        public string ParentKey;

        [Parameter(Mandatory = true, HelpMessage = "The title of the node to add")]
        public string Title;

        [Parameter(Mandatory = false, HelpMessage = "The url to navigate to when clicking the new menu item. This can either be absolute or relative to the Web. Fragments are not supported. Leave empty to create a header.")]
        [AllowEmptyString]
        public string Url = "";

        protected override void ExecuteCmdlet()
        {
            var node = new HubSiteNavigationNode()
            {
                SimpleUrl = Url,
                Title = Title,
            };

           
            var navigation = SelectedWeb.GetHubSiteData().Navigation;

            var highestKeyNode = navigation.Flatten(a => a.Nodes).OrderByDescending(p => Convert.ToInt32(p.Key)).FirstOrDefault();
            var key = Convert.ToInt32(highestKeyNode.Key) + 1;

            node.Key = key.ToString();

            if (!string.IsNullOrEmpty(ParentKey))
            {
                var parentNode = navigation.FirstOrDefaultFromMany(n => n.Nodes, p => p.Key == ParentKey);
                parentNode.Nodes.Add(node);
            } else
            {
                navigation.Add(node);
            }

            SelectedWeb.SetHubSiteMenu(navigation);

            WriteObject(node);
        }
    }
}
