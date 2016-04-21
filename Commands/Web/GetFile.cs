using System.IO;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using System;
using OfficeDevPnP.Core.Utilities;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPOFile")]
    [CmdletHelp("Downloads a file.",
        Category = CmdletHelpCategory.Webs)]
    [CmdletExample(
        Code = @"PS:> Get-SPOFile -ServerRelativeUrl /sites/project/_catalogs/themes/15/company.spcolor",
        Remarks = "Downloads the file and saves it to the current folder",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-SPOFile -ServerRelativeUrl /sites/project/_catalogs/themes/15/company.spcolor -Path c:\temp -FileName company.spcolor",
        Remarks = "Downloads the file and saves it to c:\\temp\\company.spcolor",
        SortOrder = 2)]
    [CmdletExample(Code = @"PS:> Get-SPOFile -ServerRelativeUrl /sites/project/_catalogs/themes/15/company.spcolor -AsString",
        Remarks = "Downloads the file and outputs its contents to the console",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Get-SPOFile -SiteRelativeUrl _catalogs/themes/15/company.spcolor -Path c:\temp -FileName company.spcolor",
        Remarks = "Refers to the file by site relative URL, downloads the file and saves it to c:\\temp\\company.spcolor",
        SortOrder = 4)]

    public class GetFile : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "SERVER", Position = 0, ValueFromPipeline = true)]
        public string ServerRelativeUrl = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = "SITE", Position = 0, ValueFromPipeline = true)]
        public string SiteRelativeUrl = string.Empty;

        [Parameter(Mandatory = false)]
        public string Path = string.Empty;

        [Parameter(Mandatory = false)]
        public string Filename = string.Empty;

        [Parameter(Mandatory = false)]
        public SwitchParameter AsString;

        protected override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Path))
            {
                Path = SessionState.Path.CurrentFileSystemLocation.Path;
            }

            if (ParameterSetName == "SITE")
            {
                var webUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);
                ServerRelativeUrl = UrlUtility.Combine(webUrl, SiteRelativeUrl);
            }

            if (this.MyInvocation.BoundParameters.ContainsKey("AsString"))
            {
                WriteObject(SelectedWeb.GetFileAsString(ServerRelativeUrl));
            }
            else
            {
                SelectedWeb.SaveFileToLocal(ServerRelativeUrl, Path, Filename);
            }

        }
    }
}
