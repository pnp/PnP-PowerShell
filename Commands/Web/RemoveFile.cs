using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using Resources = OfficeDevPnP.PowerShell.Commands.Properties.Resources;
using System;
using OfficeDevPnP.Core.Utilities;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Remove, "SPOFile", SupportsShouldProcess = true)]
    [CmdletHelp("Removes a file.",
        Category = CmdletHelpCategory.Webs)]
    [CmdletExample(
        Code = @"PS:>Remove-SPOFile -ServerRelativeUrl /sites/project/_catalogs/themes/15/company.spcolor",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:>Remove-SPOFile -SiteRelativeUrl _catalogs/themes/15/company.spcolor",
        SortOrder = 2)]

    public class RemoveFile : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "SERVER")]
        public string ServerRelativeUrl = string.Empty;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "SITE")]
        public string SiteRelativeUrl = string.Empty;

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSetName == "SITE")
            {
                var webUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);
                ServerRelativeUrl = UrlUtility.Combine(webUrl, SiteRelativeUrl);
            }

            var file = SelectedWeb.GetFileByServerRelativeUrl(ServerRelativeUrl);

            ClientContext.Load(file, f => f.Name);
            ClientContext.ExecuteQueryRetry();

            if (Force || ShouldContinue(string.Format(Resources.Delete0, file.Name), Resources.Confirm))
            {
                file.DeleteObject();

                ClientContext.ExecuteQueryRetry();
            }

        }
    }
}
