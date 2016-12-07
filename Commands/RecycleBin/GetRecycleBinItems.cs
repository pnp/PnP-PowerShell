using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Extensions;

namespace SharePointPnP.PowerShell.Commands.RecycleBin
{
    [Cmdlet(VerbsCommon.Get, "PnPRecycleBinItems")]
    [CmdletHelp("Returns the items in the recycle bin from the context",
        Category = CmdletHelpCategory.RecycleBin,
        OutputType = typeof(RecycleBinItem),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.recyclebinitem.aspx")]
    [CmdletExample(
        Code = @"PS:> Get-PnPRecycleBinItems",
        Remarks = "Returns all items in both the first and the second stage recycle bins in the current site collection",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPRecycleBinItems | ? ItemState -eq ""FirstStageRecycleBin""",
        Remarks = "Returns all items in only the first stage recycle bin in the current site collection",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Get-PnPRecycleBinItems | ? ItemState -eq ""SecondStageRecycleBin""",
        Remarks = "Returns all items in only the second stage recycle bin in the current site collection",
        SortOrder = 3)]
    public class GetRecycleBinItems : SPOCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            ClientContext.Site.LoadProperties(s => s.RecycleBin);
            
            var recycleBinItemList = ClientContext.Site.RecycleBin.ToList();
            WriteObject(recycleBinItemList, true);
        }
    }
}
