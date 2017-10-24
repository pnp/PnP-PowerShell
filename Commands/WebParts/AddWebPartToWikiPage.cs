using System.IO;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using File = System.IO.File;

namespace SharePointPnP.PowerShell.Commands.WebParts
{
    [Cmdlet(VerbsCommon.Add, "PnPWebPartToWikiPage")]
    [CmdletHelp("Adds a webpart to a wiki page in a specified table row and column",
        Category = CmdletHelpCategory.WebParts)]
    [CmdletExample(
        Code = @"PS:> Add-PnPWebPartToWikiPage -ServerRelativePageUrl ""/sites/demo/sitepages/home.aspx"" -Path ""c:\myfiles\listview.webpart"" -Row 1 -Column 1",
        Remarks = @"This will add the webpart as defined by the XML in the listview.webpart file to the specified page in the first row and the first column of the HTML table present on the page", SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Add-PnPWebPartToWikiPage -ServerRelativePageUrl ""/sites/demo/sitepages/home.aspx"" -XML $webpart -Row 1 -Column 1",
        Remarks = @"This will add the webpart as defined by the XML in the $webpart variable to the specified page in the first row and the first column of the HTML table present on the page", SortOrder = 2)]
    public class AddWebPartToWikiPage : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Full server relative url of the webpart page, e.g. /sites/demo/sitepages/home.aspx")]
        [Alias("PageUrl")]
        public string ServerRelativePageUrl = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = "XML", HelpMessage = "A string containing the XML for the webpart.")]
        public string Xml = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = "FILE", HelpMessage = "A path to a webpart file on a the file system.")]
        public string Path = string.Empty;

        [Parameter(Mandatory = true, HelpMessage = "Row number where the webpart must be placed")]
        public int Row;

        [Parameter(Mandatory = true, HelpMessage = "Column number where the webpart must be placed")]
        public int Column;

        [Parameter(Mandatory = false, HelpMessage = "Must there be a extra space between the webpart")]
        public SwitchParameter AddSpace;

        protected override void ExecuteCmdlet()
        {
            var serverRelativeWebUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);

            if (!ServerRelativePageUrl.ToLowerInvariant().StartsWith(serverRelativeWebUrl.ToLowerInvariant()))
            {
                ServerRelativePageUrl = UrlUtility.Combine(serverRelativeWebUrl, ServerRelativePageUrl);
            }


            WebPartEntity wp = null;

            switch (ParameterSetName)
            {
                case "FILE":
                    if (!System.IO.Path.IsPathRooted(Path))
                    {
                        Path = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Path);
                    }
                    if (File.Exists(Path))
                    {
                        var fileStream = new StreamReader(Path);
                        var webPartString = fileStream.ReadToEnd();
                        fileStream.Close();

                        wp = new WebPartEntity { WebPartXml = webPartString };
                    }
                    break;
                case "XML":
                    wp = new WebPartEntity { WebPartXml = Xml };
                    break;
            }
            if (wp != null)
            {
                SelectedWeb.AddWebPartToWikiPage(ServerRelativePageUrl, wp, Row, Column, AddSpace);
            }
        }
    }
}
