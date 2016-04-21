using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client;
using System;
using System.Linq;
using System.Management.Automation;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.Core.Utilities;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPOWebPart")]
    [CmdletHelp("Returns a webpart definition object",
        Category = CmdletHelpCategory.WebParts)]
    [CmdletExample(
        Code = @"PS:> Get-SPOWebPart -ServerRelativePageUrl ""/sites/demo/sitepages/home.aspx""",
        Remarks = @"Returns all webparts defined on the given page.", SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-SPOWebPart -ServerRelativePageUrl ""/sites/demo/sitepages/home.aspx"" -Identity a2875399-d6ff-43a0-96da-be6ae5875f82",
        Remarks = @"Returns a specific webpart defined on the given page.", SortOrder = 2)]
    public class GetWebPart : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Full server relative url of the webpart page, e.g. /sites/mysite/sitepages/home.aspx")]
        [Alias("PageUrl")]
        public string ServerRelativePageUrl = string.Empty;

        [Parameter(Mandatory = false, ValueFromPipeline = true)]
        public WebPartPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var serverRelativeWebUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);

            if (!ServerRelativePageUrl.ToLowerInvariant().StartsWith(serverRelativeWebUrl.ToLowerInvariant()))
            {
                ServerRelativePageUrl = UrlUtility.Combine(serverRelativeWebUrl, ServerRelativePageUrl);
            }


            var definitions = SelectedWeb.GetWebParts(ServerRelativePageUrl);

            if (Identity != null)
            {
                if (Identity.Id != Guid.Empty)
                {
                    var wpfound = from wp in definitions where wp.Id == Identity.Id select wp;
                    if (wpfound.Any())
                    {
                        WriteObject(wpfound.FirstOrDefault());

                    }
                }
                else if (!string.IsNullOrEmpty(Identity.Title))
                {
                    var wpfound = from wp in definitions where wp.WebPart.Title == Identity.Title select wp;
                    if (wpfound.Any())
                    {
                        WriteObject(wpfound.FirstOrDefault());
                    }
                }
            }
            else
            {
                WriteObject(definitions, true);
            }
        }
    }
}
