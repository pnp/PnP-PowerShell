using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.RecycleBin
{
    [Cmdlet(VerbsCommon.Clear, "PnpRecycleBinItems")]
    [CmdletHelp("Permanently deletes all the items in the recycle bins from the context",
        Category = CmdletHelpCategory.RecycleBin)]
    [CmdletExample(
        Code = @"PS:> Clear-PnpRecycleBinItems",
        Remarks = "Permanently deletes all the items in the first and second stage recycle bins from the context",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Clear-PnpRecycleBinItems -SecondStageOnly",
        Remarks = "Permanently deletes all the items only in the second stage recycle bin from the context",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Clear-PnpRecycleBinItems -Force",
        Remarks = "Permanently deletes all the items in the first and second stage recycle bins from the context without asking for confirmation from the end user first",
        SortOrder = 3)]
    public class ClearRecycleBinItems : SPOCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "If provided, only all the items in the second stage recycle bin will be cleared")]
        public SwitchParameter SecondStageOnly = false;

        [Parameter(Mandatory = false, HelpMessage = "If provided, no confirmation will be asked to clear the recycle bin")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (SecondStageOnly)
            {
                if (Force || ShouldContinue(Resources.ClearSecondStageRecycleBin, Resources.Confirm))
                {
                    ClientContext.Site.RecycleBin.DeleteAllSecondStageItems();
                    ClientContext.ExecuteQueryRetry();
                }
            }
            else
            {
                if (Force || ShouldContinue(Resources.ClearBothRecycleBins, Resources.Confirm))
                {
                    ClientContext.Site.RecycleBin.DeleteAll();
                    ClientContext.ExecuteQueryRetry();
                }
            }            
        }
    }
}
