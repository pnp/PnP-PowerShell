using System.Management.Automation;
using OfficeDevPnP.Core.Framework.Graph;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Graph
{
    [Cmdlet(VerbsCommon.Remove, "PnPDeletedUnifiedGroup")]

    [CmdletHelp("Permanently removes one deleted Office 365 Group (aka Unified Group)",
        Category = CmdletHelpCategory.Graph,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = "PS:> Remove-PnPDeletedUnifiedGroup -Identity 38b32e13-e900-4d95-b860-fb52bc07ca7f",
        Remarks = "Permanently removes a deleted Office 365 Group based on its ID",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> $group = Get-PnPDeletedUnifiedGroup -Identity 38b32e13-e900-4d95-b860-fb52bc07ca7f
PS:> Remove-PnPDeletedUnifiedGroup -Identity $group",
        Remarks = "Permanently removes the provided deleted Office 365 Group",
        SortOrder = 2)]

    public class RemoveDeletedUnifiedGroup : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Identity of the deleted Office 365 Group")]
        public UnifiedGroupPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var group = Identity?.GetDeletedGroup(AccessToken);

            if (group != null)
            {
                UnifiedGroupsUtility.PermanentlyDeleteUnifiedGroup(group.GroupId, AccessToken);
            }
        }
    }
}
