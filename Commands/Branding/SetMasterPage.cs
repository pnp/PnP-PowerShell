using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "SPOMasterPage")]
    [CmdletHelp("Sets the default master page of the current web.",
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
        Code = @"
    PS:> Set-SPOMasterPage -MasterPageServerRelativeUrl /sites/projects/_catalogs/masterpage/oslo.master
", SortOrder = 1)]
    public class SetMasterPage : SPOWebCmdlet
    {
        [Parameter(Mandatory = false)]
        [Alias("MasterPageUrl")]
        public string MasterPageServerRelativeUrl = null;

        [Parameter(Mandatory = false)]
        [Alias("CustomMasterPageUrl")]
        public string CustomMasterPageServerRelativeUrl = null;

        protected override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(MasterPageServerRelativeUrl))
                SelectedWeb.SetMasterPageByUrl(MasterPageServerRelativeUrl);

            if (!string.IsNullOrEmpty(CustomMasterPageServerRelativeUrl))
                SelectedWeb.SetCustomMasterPageByUrl(CustomMasterPageServerRelativeUrl);

        }
    }
}
