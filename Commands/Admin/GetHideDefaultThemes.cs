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
    [Cmdlet(VerbsCommon.Get, "PnPHideDefaultThemes")]
    [CmdletHelp(@"Returns if the default / OOTB themes should be visible to users or not.",
        DetailedDescription = @"Returns if the default themes are visible. Use Set-PnPHideDefaultThemes to change this value.

You must be a SharePoint Online global administrator to run the cmdlet.",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
        Code = @"PS:> Get-PnPHideDefaultThemes",
        Remarks = @"This example returns the current setting if the default themes should be visible", SortOrder = 1)]
    public class GetHideDefaultThemes : PnPAdminCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var value = Tenant.EnsureProperty(t => t.HideDefaultThemes);
            WriteObject(value);
        }
    }
}
#endif