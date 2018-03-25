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
    [Cmdlet(VerbsCommon.Set, "PnPInPlaceRecordsManagement")]
    [CmdletHelp("Activates or deactivates in the place records management feature.",
        Category = CmdletHelpCategory.RecordsManagement)]
    [CmdletExample(
        Code = @"PS:> Set-PnPInPlaceRecordsManagement -Enabled $true",
        Remarks = "Activates In Place Records Management",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-PnPInPlaceRecordsManagement -Enabled $false",
        Remarks = "Deactivates In Place Records Management",
        SortOrder = 2)]
    public class SetInPlaceRecordsManagement : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName="Enable or Disable")]
        public bool Enabled;

        [Obsolete("Use -Enabled $true")]
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Turn records management on", ParameterSetName = "On")]
        public SwitchParameter On;

        [Obsolete("Use -Enabled $false")]
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Turn records management off", ParameterSetName = "Off")]
        public SwitchParameter Off;

        protected override void ExecuteCmdlet()
        {
            if (MyInvocation.BoundParameters.ContainsKey("Enabled"))
            {
                if (Enabled)
                {
                    ClientContext.Site.ActivateInPlaceRecordsManagementFeature();
                }
                else
                {
                    ClientContext.Site.DisableInPlaceRecordsManagementFeature();
                }
            }
            else
            {
                // obsolete
                if (MyInvocation.BoundParameters.ContainsKey("On"))
                {
                    ClientContext.Site.ActivateInPlaceRecordsManagementFeature();
                }
                else
                {
                    ClientContext.Site.DisableInPlaceRecordsManagementFeature();
                }
            }
        }

    }

}
