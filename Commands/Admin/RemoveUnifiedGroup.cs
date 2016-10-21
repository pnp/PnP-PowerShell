using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet("Remove", "PnPUnifiedGroup")]
    [CmdletHelp("Removes one Office 365 Group (aka Unified Group) or a list of Office 365 Groups",
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
       Code = "PS:> Remove-PnPUnifiedGroup -Identity $groupId",
       Remarks = "Removes an Office 365 Groups based on its ID",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Remove-PnPUnifiedGroup -Identity $group",
       Remarks = "Removes the provided Office 365 Groups",
       SortOrder = 2)]
    public class RemoveUnifiedGroup : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The Identity of the Office 365 Group.")]
        public UnifiedGroupBind Identity;

        protected override void ExecuteCmdlet()
        {

        }
    }
}
