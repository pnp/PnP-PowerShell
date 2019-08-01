using System.Management.Automation;
using OfficeDevPnP.Core.Framework.Graph;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsData.Restore, "PnPDeletedUnifiedGroup")]

    [CmdletHelp("Restores one deleted Office 365 Group (aka Unified Group)",
        Category = CmdletHelpCategory.Graph,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = "PS:> Restore-PnPDeletedUnifiedGroup -Identity 38b32e13-e900-4d95-b860-fb52bc07ca7f",
        Remarks = "Restores a deleted Office 365 Group based on its ID",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> $group = Get-PnPDeletedUnifiedGroup -Identity 38b32e13-e900-4d95-b860-fb52bc07ca7f
PS:> Restore-PnPDeletedUnifiedGroup -Identity $group",
        Remarks = "Restores the provided deleted Office 365 Group",
        SortOrder = 2)]

    public class RestoreDeletedUnifiedGroup : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Identity of the deleted Office 365 Group")]
        public UnifiedGroupPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var group = Identity?.GetDeletedGroup(AccessToken);

            if (group != null)
            {
                UnifiedGroupsUtility.RestoreDeletedUnifiedGroup(group.GroupId, AccessToken);
            }
        }
    }
}