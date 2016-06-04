using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.WebPnP
{
    [Cmdlet(VerbsCommon.Remove, "SPOIndexedProperty")]
    [CmdletHelp("Removes a key from propertybag to be indexed by search. The key and it's value retain in the propertybag, however it will not be indexed anymore.",
        Category = CmdletHelpCategory.Webs)]
    public class RemovedIndexedProperty : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
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
