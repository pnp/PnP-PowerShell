#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using SharePointPnP.PowerShell.Commands.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Navigation
{
    [Cmdlet(VerbsCommon.Get, "PnPHubSiteNavigation")]
    [CmdletHelp(@"Retrieve all or a specific hubsite.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(Code = @"PS:> Get-PnPStorageEntity", Remarks = "Returns all site storage entities/farm properties", SortOrder = 1)]
    [CmdletExample(Code = @"PS:> Get-PnPTenantSite -Key MyKey", Remarks = "Returns the storage entity/farm property with the given key.", SortOrder = 2)]
    public class GetHubSiteNavigation : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = true)]
        public string Key;

        [Parameter(Mandatory = false)]
        public SwitchParameter Tree;

        protected override void ExecuteCmdlet()
        {
            var navigation = SelectedWeb.GetHubSiteData().Navigation;

            if (!Tree.IsPresent)
            {
                if (!string.IsNullOrEmpty(Key))
                {
                    var node = navigation.FirstOrDefaultFromMany(n => n.Nodes, n => n.Key == Key);
                    WriteObject(node);
                }
                else
                {
                    WriteObject(SelectedWeb.GetHubSiteData().Navigation, true);
                }
            }
            else
            {
                PrintTree(navigation, 0);
            }
        }

        private void PrintTree(List<HubSiteNavigationNode> nodes, int level)
        {
            if(level > 0)
            {
                Host.UI.Write(string.Join("",Enumerable.Repeat("│ ", level)));
            } 
            var index = 1;
            foreach (var node in nodes)
            {
                if (index == nodes.Count)
                {
                    Host.UI.Write("└");
                }
                else
                {
                    Host.UI.Write("├");
                }
                if(node.Nodes != null && node.Nodes.Any())
                {
                    Host.UI.Write("┬");
                } else
                {
                    Host.UI.Write("─");
                }
                Host.UI.WriteLine($" {node.Key} - {node.Title} - {node.SimpleUrl}");
                if (node.Nodes != null && node.Nodes.Any())
                {
                    PrintTree(node.Nodes, level + 1);
                }
                index++;
            }
        }
    }
}
#endif