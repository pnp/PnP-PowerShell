using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using OfficeDevPnP.Core.Utilities;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "SPOWebPartProperty")]
    [CmdletHelp("Sets a web part property",
        Category = CmdletHelpCategory.WebParts)]
    public class SetWebPartProperty : SPOWebCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("PageUrl")]
        public string ServerRelativePageUrl = string.Empty;

        [Parameter(Mandatory = true)]
        public GuidPipeBind Identity;

        [Parameter(Mandatory = true)]
        public string Key = string.Empty;

        [Parameter(Mandatory = true)]
        public PSObject Value = string.Empty;

        protected override void ExecuteCmdlet()
        {
            var serverRelativeWebUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);

            if (!ServerRelativePageUrl.ToLowerInvariant().StartsWith(serverRelativeWebUrl.ToLowerInvariant()))
            {
                ServerRelativePageUrl = UrlUtility.Combine(serverRelativeWebUrl, ServerRelativePageUrl);
            }


            if (Value.BaseObject is string)
            {
                SelectedWeb.SetWebPartProperty(Key, Value.ToString(), Identity.Id, ServerRelativePageUrl);
            }
            else if (Value.BaseObject is int)
            {
                SelectedWeb.SetWebPartProperty(Key, (int)Value.BaseObject, Identity.Id, ServerRelativePageUrl);
            }
        }
    }
}
