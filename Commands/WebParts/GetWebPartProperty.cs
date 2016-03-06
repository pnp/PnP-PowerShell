using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using OfficeDevPnP.Core.Utilities;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPOWebPartProperty")]
    [CmdletHelp("Returns a web part property", 
        Category = CmdletHelpCategory.WebParts)]
    [CmdletExample(
        Code = @"PS:> Get-SPOWebPartProperty -ServerRelativePageUrl /sites/demo/sitepages/home.aspx -Identity ccd2c98a-c9ae-483b-ae72-19992d583914",
        Remarks = "Returns all properties of the webpart.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Get-SPOWebPartProperty -ServerRelativePageUrl /sites/demo/sitepages/home.aspx -Identity ccd2c98a-c9ae-483b-ae72-19992d583914 -Key ""Title""",
        Remarks = "Returns the title property of the webpart.",
        SortOrder = 2)]
    public class GetWebPartProperty : SPOWebCmdlet
    {
        [Parameter(Mandatory = true)]
        [Alias("PageUrl")]
        public string ServerRelativePageUrl = string.Empty;

        [Parameter(Mandatory = true)]
        public GuidPipeBind Identity;

        [Parameter(Mandatory = false)]
        public string Key;

        protected override void ExecuteCmdlet()
        {
            var serverRelativeWebUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);

            if (!ServerRelativePageUrl.ToLowerInvariant().StartsWith(serverRelativeWebUrl.ToLowerInvariant()))
            {
                ServerRelativePageUrl = UrlUtility.Combine(serverRelativeWebUrl, ServerRelativePageUrl);
            }


            var properties = SelectedWeb.GetWebPartProperties(Identity.Id, ServerRelativePageUrl);
            var values = properties.FieldValues.Select(x => new PropertyBagValue() { Key = x.Key, Value = x.Value });
            if (!string.IsNullOrEmpty(Key))
            {
                var value = values.FirstOrDefault(v => v.Key == Key);
                if (value != null)
                {
                    WriteObject(value.Value);
                }
            }
            else
            {
                WriteObject(values, true);
            }
        }



    }
}
