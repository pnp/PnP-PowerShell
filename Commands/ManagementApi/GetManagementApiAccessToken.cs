using System;
using System.Management.Automation;
using Newtonsoft.Json.Linq;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;

namespace SharePointPnP.PowerShell.Commands.ManagementApi
{
    [Cmdlet(VerbsCommon.Get, "PnPManagementApiAccessToken")]
    [CmdletHelp("Gets access token for O365 Management API using app credentials",
        Category = CmdletHelpCategory.ManagementApi,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Connect-PnPOnline -AccessToken (Get-PnPManagementApiAccessToken -TenantId $tenantId -ClientId $clientId -ClientSecret $clientSecret)",
       Remarks = "Retrieves access token for Management API and uses it in PnP connection",
       SortOrder = 1)]
    public class GetManagementApiAccessToken : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The tenant ID to connect to the Management API.")]
        public string TenantId;

        [Parameter(Mandatory = true, HelpMessage = "The client id of the app which gives you access to the Management API.")]
        public string ClientId;

        [Parameter(Mandatory = true, HelpMessage = "The client secret of the app which gives you access to the Management API.")]
        public string ClientSecret;

        protected override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var resource = "https://manage.office.com";
            var body = $"grant_type=client_credentials&client_id={ClientId}&client_secret={ClientSecret}&resource={resource}";
            var response = HttpHelper.MakePostRequestForString($"https://login.microsoftonline.com/{TenantId}/oauth2/token", body, "application/x-www-form-urlencoded");
            try
            {
                var json = JToken.Parse(response);
                var accessToken = json["access_token"].ToString();
                WriteObject(accessToken);
            }
            catch(Exception e)
            {
                WriteError(new ErrorRecord(e, "", ErrorCategory.ProtocolError, null));
            }
        }
    }
}
