using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.RecycleBin
{
    [Cmdlet(VerbsCommon.Reset, "PnpRecycleBinItems")]
    [CmdletHelp("Restores all the items from the first and second stage recycle bin of the current context to their original locations",
        Category = CmdletHelpCategory.RecycleBin)]
    [CmdletExample(
        Code = @"PS:> Reset-PnpRecycleBinItems",
        Remarks = "Restores all the items from the first and second stage recycle bin of the current context to their original locations",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Reset-PnpRecycleBinItems -Force",
        Remarks = "Restores all the items from the first and second stage recycle bin of the current context to their original locations without asking for confirmation first",
        SortOrder = 2)]
    public class ResetPnpRecycleBinItems : SPOCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "If provided, no confirmation will be asked to restore all the files from the first and second stage recycle bins to their original locations")]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue(Resources.ResetRecycleBinItems, Resources.Confirm))
            {
                ClientContext.Site.RecycleBin.RestoreAll();
                ClientContext.ExecuteQueryRetry();
            }                  
        }
    }
}
