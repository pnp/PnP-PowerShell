using System;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "SPOMinimalDownloadStrategy")]
    [CmdletHelp("Activates or deactivates the minimal downloading strategy.", 
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
        Code = @"PS:> Set-SPOMinimalDownloadStrategy -Off",
        Remarks = "Will deactivate minimal download strategy (MDS) for the current web.",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-SPOMinimalDownloadStrategy -On",
        Remarks = "Will activate minimal download strategy (MDS) for the current web.",
        SortOrder = 2)]
    public class SetMDS : SPOWebCmdlet
    {
        [Parameter(ParameterSetName = "On", Mandatory = true)]
        public SwitchParameter On;

        [Parameter(ParameterSetName = "Off", Mandatory = true)]
        public SwitchParameter Off;

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (On)
            {
                SelectedWeb.Features.Add(OfficeDevPnP.Core.Constants.MINIMALDOWNLOADSTRATEGYFEATUREID, Force, FeatureDefinitionScope.None);
            }
            else
            {
                SelectedWeb.Features.Remove(OfficeDevPnP.Core.Constants.MINIMALDOWNLOADSTRATEGYFEATUREID, Force);
            }
            ClientContext.ExecuteQueryRetry();
        }
    }

}
