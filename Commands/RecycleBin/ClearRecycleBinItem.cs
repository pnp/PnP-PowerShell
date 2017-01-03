using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.RecycleBin
{
    [Cmdlet(VerbsCommon.Clear, "PnpRecycleBinItem")]
    [CmdletHelp("Permanently deletes the provided recycle bin item",
        Category = CmdletHelpCategory.RecycleBin)]
    [CmdletExample(
        Code = @"PS:> Get-PnPRecycleBinItems | ? FileLeafName -like ""*.docx"" | Clear-PnpRecycleBinItem",
        Remarks = "Permanently deletes all the items in the first and second stage recycle bins of which the file names have the .docx extension",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Clear-PnpRecycleBinItem -Identity 72e4d749-d750-4989-b727-523d6726e442",
        Remarks = "Permanently deletes the recycle bin item with Id 72e4d749-d750-4989-b727-523d6726e442 from the recycle bin",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Clear-PnpRecycleBinItem -Identity $item -Force",
        Remarks = "Permanently deletes the recycle bin item stored under variable $item from the recycle bin without asking for confirmation from the end user first",
        SortOrder = 3)]
    public class ClearRecycleBinItem : SPOCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "If provided, no confirmation will be asked to permanently delete the recycle bin item")]
        public SwitchParameter Force;

        [Parameter(Mandatory = true, HelpMessage = "Id of the recycle bin item or the recycle bin item itself to permanently delete", ValueFromPipeline = true)]
        public RecycleBinItemPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var recycleBinItem = Identity.GetRecycleBinItem(ClientContext.Site);
            ClientContext.Load(recycleBinItem);
            ClientContext.ExecuteQueryRetry();

            if (Force || ShouldContinue(string.Format(Resources.ClearRecycleBinItem, recycleBinItem.LeafName), Resources.Confirm))
            {
                recycleBinItem.DeleteObject();
                ClientContext.ExecuteQueryRetry();
            }      
        }
    }
}
