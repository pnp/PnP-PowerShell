using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Enums;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.Branding
{
    [Cmdlet(VerbsCommon.Remove, "PnPNavigationNode", SupportsShouldProcess = true)]
    [CmdletHelp("Removes a menu item from either the quicklaunch or top navigation", 
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(Code = @"PS:> Remove-PnPNavigationNode -Title Recent -Location QuickLaunch",
        Remarks = "Will remove the recent navigation node from the quick launch in the current web.",
        SortOrder = 1)]
    [CmdletExample(Code = @"PS:> Remove-PnPNavigationNode -Title Home -Location TopNavigationBar -Force",
        Remarks = "Will remove the home navigation node from the top navigation bar without prompting for a confirmation in the current web.",
        SortOrder = 2)]
    [CmdletExample(Code = @"PS:> Remove-PnPNavigationNode -Location QuickLaunch -All",
        Remarks = "Will all the navigation nodes from the quick launch bar in the current web.",
        SortOrder = 4)]
    public class RemoveNavigationNode : PnPWebCmdlet
    {
        private const string ParameterSet_RemoveOneNavigationNode = "By Title and Location";
        private const string ParameterSet_RemoveAllNavigationNode = "By Location";

        [Parameter(Mandatory = true, HelpMessage = "The location of the node(s) to remove (QuickLaunch, SearchNav, TopNavigationBar)")]
        public NavigationType Location;

        [Parameter(Mandatory = true, HelpMessage = "The title of the node that needs to be removed", ParameterSetName = ParameterSet_RemoveOneNavigationNode)]
        public string Title;

        [Parameter(Mandatory = false, HelpMessage = "The header where the node is located", ParameterSetName = ParameterSet_RemoveOneNavigationNode)]
        public string Header;

        [Parameter(Mandatory = true, HelpMessage = "Specifying the All parameter will remove all the nodes from specifed Location.", ParameterSetName = ParameterSet_RemoveAllNavigationNode)]
        public SwitchParameter All;

        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;


        protected override void ExecuteCmdlet()
        {
            if (All)
            {
                if (Force || ShouldContinue(string.Format(Resources.RemoveNavigationNodeInLocation, Location), Resources.Confirm))
                {
                    SelectedWeb.DeleteAllNavigationNodes(Location);
                }
            }
            else
            {
                if (Force || ShouldContinue(string.Format(Resources.RemoveNavigationNode0, Title), Resources.Confirm))
                {
                    SelectedWeb.DeleteNavigationNode(Title, Header, Location);
                }
            }
        }
    }
}
