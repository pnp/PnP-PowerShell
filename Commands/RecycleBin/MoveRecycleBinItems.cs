using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.RecycleBin
{
    [Cmdlet(VerbsCommon.Move, "PnpRecycleBinItems")]
    [CmdletHelp("Moves all the items in the first stage recycle bin of the current context to the second stage recycle bin",
        Category = CmdletHelpCategory.RecycleBin)]
    [CmdletExample(
        Code = @"PS:> Move-PnpRecycleBinItems",
        Remarks = "Moves all the items in the first stage recycle bin of the current context to the second stage recycle bin",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Move-PnpRecycleBinItems -Force",
        Remarks = "Moves all the items in the first stage recycle bin of the current context to the second stage recycle bin without asking for confirmation first",
        SortOrder = 2)]
    public class MoveRecycleBinItems : SPOCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "If provided, no confirmation will be asked to move the first stage recycle bin items to the second stage")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue(Resources.MoveFirstStageRecycleBinItemsToSecondStage, Resources.Confirm))
            {
                ClientContext.Site.RecycleBin.MoveAllToSecondStage();
                ClientContext.ExecuteQueryRetry();
            }                  
        }
    }
}
