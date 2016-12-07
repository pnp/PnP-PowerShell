using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.RecycleBin
{
    [Cmdlet(VerbsCommon.Reset, "PnpRecycleBinItem")]
    [CmdletHelp("Restores the provided recycle bin item to its original location",
        Category = CmdletHelpCategory.RecycleBin)]
    [CmdletExample(
        Code = @"PS:> Get-PnPRecycleBinItems | ? FileLeafName -like ""*.docx"" | Reset-PnpRecycleBinItem",
        Remarks = "Restores all the items in the first and second stage recycle bins to their original location of which the filename ends with the .docx extension",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Reset-PnpRecycleBinItem -Identity 72e4d749-d750-4989-b727-523d6726e442",
        Remarks = "Restores the recycle bin item with Id 72e4d749-d750-4989-b727-523d6726e442 to its original location",
        SortOrder = 2)]
    public class ResetRecycleBinItem : SPOCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "If provided, no confirmation will be asked to restore the recycle bin item")]
        public SwitchParameter Force;

        [Parameter(Mandatory = true, HelpMessage = "Id of the recycle bin item or the recycle bin item itself to restore", ValueFromPipeline = true)]
        public RecycleBinItemPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var recycleBinItem = Identity.GetRecycleBinItem(ClientContext.Site);
            ClientContext.Load(recycleBinItem);
            ClientContext.ExecuteQueryRetry();

            if (Force || ShouldContinue(string.Format(Resources.ResetRecycleBinItem, recycleBinItem.LeafName), Resources.Confirm))
            {
                recycleBinItem.Restore();
                ClientContext.ExecuteQueryRetry();
            }      
        }
    }
}
