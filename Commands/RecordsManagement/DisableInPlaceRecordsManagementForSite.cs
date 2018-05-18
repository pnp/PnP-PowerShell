using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Collections.Generic;
using SharePointPnP.PowerShell.Commands.Base;

namespace SharePointPnP.PowerShell.Commands.RecordsManagement
{
    [Cmdlet(VerbsLifecycle.Disable, "PnPInPlaceRecordsManagementForSite")]
    [CmdletHelp("Disables in place records management for a site.",
        Category = CmdletHelpCategory.RecordsManagement)]
    [CmdletExample(
        Code = @"PS:> Disable-PnPInPlaceRecordsManagementForSite",
        Remarks = "The in place records management feature will be disabled",
        SortOrder = 1)]

    [Obsolete("Use Set-PnPInPlaceRecordsManagement -Enabled $false instead")]
    public class DisableInPlaceRecordsManagementForSite : PnPCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            this.ClientContext.Site.DisableInPlaceRecordsManagementFeature();
        }

    }

}
