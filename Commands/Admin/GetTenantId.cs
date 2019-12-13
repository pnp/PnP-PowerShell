#if !ONPREMISES
using Microsoft.SharePoint.Client;
using Newtonsoft.Json.Linq;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Get, "PnPTenantId")]
    [CmdletHelp(@"Returns the Tenant ID",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
        Code = @"PS:> Get-PnPTenantId",
        Remarks = @"Returns the current Tenant Id. A valid connection with Connect-PnPOnline is required.", SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPTenantId -TenantUrl https://contoso.sharepoint.com",
        Remarks = @"Returns the Tenant ID for the specified tenant. Can be executed without a connecting first with Connect-PnPOnline", SortOrder = 1)]
    public class GetTenantId : BasePSCmdlet
    {
        [Parameter(Mandatory = false)]
        public string TenantUrl;

        protected override void ProcessRecord()
        {
            try
            {
                if (string.IsNullOrEmpty(TenantUrl) && SPOnlineConnection.CurrentConnection != null)
                {
                    WriteObject(TenantExtensions.GetTenantIdByUrl(SPOnlineConnection.CurrentConnection.Url));
                }
                else if (!string.IsNullOrEmpty(TenantUrl))
                {
                    WriteObject(TenantExtensions.GetTenantIdByUrl(TenantUrl));
                }
                else
                {
                    throw new InvalidOperationException("Either a connection needs to be made by Connect-PnPOnline or TenantUrl needs to be specified");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException is HttpException)
                    {
                        var message = ex.InnerException.Message;
                        var obj = JObject.Parse(message);
                        WriteObject(obj["error_description"].ToString());
                    }
                    else
                    {
                        throw ex;
                    }
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}
#endif