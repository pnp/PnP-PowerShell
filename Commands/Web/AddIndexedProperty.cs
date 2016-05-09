using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "SPOIndexedProperty")]
    [CmdletHelp("Marks the value of the propertybag key to be indexed by search.",
        Category = CmdletHelpCategory.Webs)]
    public class AddIndexedProperty : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Key;

        protected override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Key))
            {
                SelectedWeb.AddIndexedPropertyBagKey(Key);
            }
        }
    }
}
