#if !ONPREMISES
using System;
using System.Linq.Expressions;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsCommon.Set, "PnPSite")]
    [CmdletHelp("Sets Site Collection properties.",
        Category = CmdletHelpCategory.Sites,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSite -Classification ""HBI""",
        Remarks = "Sets the current site classification to HBI",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSite -Classification $null",
        Remarks = "Unsets the current site classification",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSite -DisableFlows",
        Remarks = "Disables Flows for this site",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSite -DisableFlows:$false",
        Remarks = "Enables Flows for this site",
        SortOrder = 3)]
    public class SetSite : PnPCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The classification to set")]
        public string Classification;

        [Parameter(Mandatory = false, HelpMessage = "Disables flows for this site")]
        public SwitchParameter DisableFlows;

        protected override void ExecuteCmdlet()
        {
            var site = ClientContext.Site;
            if (MyInvocation.BoundParameters.ContainsKey("Classification"))
            {
                site.Classification = Classification;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DisableFlows"))
            {
                site.DisableFlows = DisableFlows;
            }
            

            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif