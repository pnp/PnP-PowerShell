using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.Graph;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet("Get", "PnPUnifiedGroupMembers")]
    [CmdletHelp("Gets members of a paricular Office 365 Group (aka Unified Group)",
        Category = CmdletHelpCategory.Graph,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroupMembers",
       Remarks = "Retrieves all the members of an Office 365 Group",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroupMembers -Identity $groupId",
       Remarks = "Retrieves all the members of a specific Office 365 Group based on its ID",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedGroupMembers -Identity $group",
       Remarks = "Retrieves all the members of a specific Office 365 Group based on the group's object instance",
       SortOrder = 3)]
    public class GetUnifiedGroupMembers : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The Identity of the Office 365 Group.")]
        public UnifiedGroupPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            UnifiedGroupEntity group = null;

            if (Identity != null)
            {
                // We have to retrieve a specific group
                if (Identity.Group != null)
                {
                    group = UnifiedGroupsUtility.GetUnifiedGroup(Identity.Group.GroupId, AccessToken, includeSite: false);
                }
                else if (!String.IsNullOrEmpty(Identity.GroupId))
                {
                    group = UnifiedGroupsUtility.GetUnifiedGroup(Identity.GroupId, AccessToken, includeSite: false);
                }
            }

            if (group != null)
            {
                // Get members of the group.

                List<UnifiedGroupUser> members = UnifiedGroupsUtility.GetUnifiedGroupMembers(group, AccessToken);
                WriteObject(members);
            }

        }
    }
}
