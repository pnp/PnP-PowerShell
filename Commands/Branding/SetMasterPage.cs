using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using System;
using OfficeDevPnP.Core.Utilities;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "SPOMasterPage")]
    [CmdletHelp("Sets the default master page of the current web.",
        Category = CmdletHelpCategory.Branding)]
    [CmdletExample(
        Code = @"PS:> Set-SPOMasterPage -MasterPageServerRelativeUrl /sites/projects/_catalogs/masterpage/oslo.master",
        Remarks = "Sets the master page based on a server relative URL", 
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-SPOMasterPage -MasterPageSiteRelativeUrl _catalogs/masterpage/oslo.master",
        Remarks = "Sets the master page based on a site relative URL",
        SortOrder = 2)]
    public class SetMasterPage : SPOWebCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName = "SERVER")]
        [Alias("MasterPageUrl")]
        public string MasterPageServerRelativeUrl = null;

        [Parameter(Mandatory = false, ParameterSetName = "SERVER")]
        [Alias("CustomMasterPageUrl")]
        public string CustomMasterPageServerRelativeUrl = null;

        [Parameter(Mandatory = false, ParameterSetName = "SITE")]
        public string MasterPageSiteRelativeUrl = null;

        [Parameter(Mandatory = false, ParameterSetName = "SITE")]
        public string CustomMasterPageSiteRelativeUrl = null;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSetName == "SERVER")
            {
                if (!string.IsNullOrEmpty(MasterPageServerRelativeUrl))
                    SelectedWeb.SetMasterPageByUrl(MasterPageServerRelativeUrl);

                if (!string.IsNullOrEmpty(CustomMasterPageServerRelativeUrl))
                    SelectedWeb.SetCustomMasterPageByUrl(CustomMasterPageServerRelativeUrl);
            }
            else
            {
                if (!string.IsNullOrEmpty(MasterPageSiteRelativeUrl))
                {
                    SelectedWeb.SetMasterPageByUrl(GetServerRelativeUrl(MasterPageSiteRelativeUrl));
                }
                if (!string.IsNullOrEmpty(CustomMasterPageSiteRelativeUrl))
                {
                    SelectedWeb.SetCustomMasterPageByUrl(GetServerRelativeUrl(CustomMasterPageSiteRelativeUrl));
                }
            }
        }

        private string GetServerRelativeUrl(string url)
        {
            var serverRelativeUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);
            return UrlUtility.Combine(serverRelativeUrl, url);
        }
    }
}
