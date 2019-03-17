using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "PnPIndexedProperty")]
    [CmdletHelp("Marks the value of the propertybag key specified to be indexed by search.",
        Category = CmdletHelpCategory.Webs)]
    public class AddIndexedProperty : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = @"Key of the property bag value to be indexed")]
        public string Key;

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The list object or name where to set the indexed property")]
        public ListPipeBind List;

        protected override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Key))
            {
                if (List != null)
                {
                    var list = List.GetList(SelectedWeb);
                    if (list != null)
                    {
                        list.AddIndexedPropertyBagKey(Key);
                    }
                }
                else
                {
                    SelectedWeb.AddIndexedPropertyBagKey(Key);
                }
            }
        }
    }
}
