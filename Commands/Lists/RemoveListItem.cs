using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client;
using System.Management.Automation;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;

namespace OfficeDevPnP.PowerShell.Commands.Lists
{
    [Cmdlet(VerbsCommon.Remove, "SPOListItem", SupportsShouldProcess = true)]
    [CmdletHelp("Deletes an item from a list",
        Category = CmdletHelpCategory.Lists)]
    [CmdletExample(
        Code = @"PS:> Remove-SPOListItem -Identity ""Demo List"" -Id ""1"" -Force",
        SortOrder = 1,
        Remarks = @"Removes the listitem with Id ""1"" from the ""Demo List"" list.")]
    public class RemoveListItem : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The ID or Title of the list.")]
        public ListPipeBind Identity = new ListPipeBind();

        [Parameter(Mandatory = false, HelpMessage = "The ID of the item to retrieve")]
        public int Id = -1;

        [Parameter(Mandatory = false, HelpMessage = "The unique id (GUID) of the item to retrieve")]
        public GuidPipeBind UniqueId;

        [Parameter(Mandatory = false)] public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            var list = Identity.GetList(SelectedWeb);
            if (Identity != null)
            {
                var listItem = list.GetItemById(Id);
                if (Id != -1)
                {
                    ClientContext.Load(listItem);
                    ClientContext.ExecuteQueryRetry();
                    if (Force || ShouldContinue(Properties.Resources.RemoveList, Properties.Resources.Confirm))
                    {
                        listItem.DeleteObject();
                        ClientContext.ExecuteQueryRetry();
                    }
                }
            }
        }
     }
}
