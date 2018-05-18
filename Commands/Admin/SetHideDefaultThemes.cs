#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;
using OfficeDevPnP.Core.Sites;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using SharePointPnP.PowerShell.Commands.Enums;
using System.Collections.Generic;
using SharePointPnP.PowerShell.Commands.Model;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Set, "PnPHideDefaultThemes")]
    [CmdletHelp(@"Defines if the default / OOTB themes should be visible to users or not.",
        DetailedDescription = @"Use this cmdlet to hide or show the default themes to users

You must be a SharePoint Online global administrator to run the cmdlet.",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
        Code = @"PS:> Set-PnPHideDefaultThemes -HideDefaultThemes $true",
        Remarks = @"This example hides the default themes", SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-PnPHideDefaultThemes -HideDefaultThemes $false",
        Remarks = @"This example shows the default themes", SortOrder = 1)]
    public class SetHideDefaultThemes : PnPAdminCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Defines if the default themes should be visible or hidden")]
        public bool HideDefaultThemes = false;

        protected override void ExecuteCmdlet()
        {
            Tenant.HideDefaultThemes = HideDefaultThemes;
            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif