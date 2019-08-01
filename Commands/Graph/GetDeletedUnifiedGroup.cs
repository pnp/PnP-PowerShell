using System.Collections.Generic;
using System.Management.Automation;
using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.Graph;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Get, "PnPDeletedUnifiedGroup")]

    [CmdletHelp("Gets one deleted Office 365 Group (aka Unified Group) or a list of deleted Office 365 Groups",
        Category = CmdletHelpCategory.Graph,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = "PS:> Get-PnPDeletedUnifiedGroup",
        Remarks = "Retrieves all deleted Office 365 Groups",
        SortOrder = 1)]
    [CmdletExample(
        Code = "PS:> Get-PnPDeletedUnifiedGroup -Identity 38b32e13-e900-4d95-b860-fb52bc07ca7f",
        Remarks = "Retrieves a specific deleted Office 365 Group based on its ID",
        SortOrder = 2)]

    public class GetDeletedUnifiedGroup : PnPGraphCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The Identity of the Office 365 Group.")]
        public UnifiedGroupPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            UnifiedGroupEntity group = null;
            List<UnifiedGroupEntity> groups = null;

            if (Identity != null)
            {
                group = Identity.GetDeletedGroup(AccessToken);
            }
            else
            {
                groups = UnifiedGroupsUtility.ListDeletedUnifiedGroups(AccessToken);
            }

            if (group != null)
            {
                WriteObject(group);
            }
            else if (groups != null)
            {
                WriteObject(groups, true);
            }
        }
    }
}
