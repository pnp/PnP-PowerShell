using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Remove, "PnPIndexedProperty")]
    [CmdletHelp("Removes a key from propertybag to be indexed by search. The key and it's value remain in the propertybag, however it will not be indexed anymore.",
        Category = CmdletHelpCategory.Webs)]
    [CmdletExample(
        Code = @"PS:> Remove-PnPIndexedProperty -key ""MyIndexProperty""", 
        Remarks = @"Removes the Indexed property ""MyIndexProperty"" from the current web", 
        SortOrder = 1)]
    public class RemovedIndexedProperty : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = @"Key of the property bag value to be removed from indexing")]
        public string Key;

        protected override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Key))
            {
                SelectedWeb.RemoveIndexedPropertyBagKey(Key);
            }
        }
    }
}
