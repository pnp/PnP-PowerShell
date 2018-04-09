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
    [Cmdlet(VerbsLifecycle.Enable, "PnPInPlaceRecordsManagementForSite")]
    [CmdletHelp("Enables in place records management for a site.",
        Category = CmdletHelpCategory.RecordsManagement)]
    [CmdletExample(
        Code = @"PS:> Enable-PnPInPlaceRecordsManagementForSite",
        Remarks = "The in place records management feature will be enabled and the in place record management will be enabled in all locations with record declaration allowed by all contributors and undeclaration by site admins",
        SortOrder = 1)]
    [Obsolete("Use Set-PnPInPlaceRecordsManagement -Enabled $true instead")]
    public class EnableInPlaceRecordsManagementForSite : PnPCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            this.ClientContext.Site.EnableSiteForInPlaceRecordsManagement();
        }

    }

}