#if !ONPREMISES
using Newtonsoft.Json.Linq;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsLifecycle.Request, "PnPAccessToken")]
    [CmdletHelp("Requests an OAuth Access token",
        "Returns an access token using the password grant, using the PnP O365 Management Shell client id by default and the AllSites.FullControl scope by default.",
        Category = CmdletHelpCategory.Base)]
    [CmdletExample(
       Code = "PS:> Request-PnPAccessToken",
       Remarks = "Returns the access token using the default client id and scope",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Request-PnPAccessToken -ClientId 26e29fec-aa10-4f99-8381-d96cddc650c2",
       Remarks = "Returns the access token using the specified client id and the default scope of AllSites.FullControl",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Request-PnPAccessToken -ClientId 26e29fec-aa10-4f99-8381-d96cddc650c2 -Scopes Group.ReadWrite.All",
       Remarks = "Returns the access token using the specified client id and the specified scope",
       SortOrder = 3)]
    [CmdletExample(
       Code = "PS:> Request-PnPAccessToken -ClientId 26e29fec-aa10-4f99-8381-d96cddc650c2 -Scopes Group.ReadWrite.All, AllSites.FullControl",
       Remarks = "Returns the access token using the specified client id and the specified scopes",
       SortOrder = 4)]
    [CmdletExample(
       Code = @"PS:> $token = Request-PnPAccessToken -ClientId 26e29fec-aa10-4f99-8381-d96cddc650c2 -Resource https://contoso.sharepoint.com -Credentials (Get-Credential) -TenantUrl https://contoso.sharepoint.com
    Connect-PnPOnline -AccessToken $token",
       Remarks = "Returns the access token using the specified client id and the specified scopes while using the credentials and tenanturl specified to authentication against Azure AD",
       SortOrder = 5)]
    public class RequestAccessToken : BasePSCmdlet
    {

        [Parameter(Mandatory = false, HelpMessage = "The Azure Application Client Id to use to retrieve the token. Defaults to the PnP Office 365 Management Shell")]
        public string ClientId = SPOnlineConnection.DeviceLoginAppId; // defaults to PnPO365ManagementShell

        [Parameter(Mandatory = false, HelpMessage = "The scopes to retrieve the token for. Defaults to AllSites.FullControl")]
        public string Resource;

        [Parameter(Mandatory = false, HelpMessage = "The scopes to retrieve the token for. Defaults to AllSites.FullControl")]
        public List<string> Scopes = new List<string> { "AllSites.FullControl" };

        [Parameter(Mandatory = false, HelpMessage = "Returns the token in a decoded / human readible manner")]
        public SwitchParameter Decoded;

        [Parameter(Mandatory = false, HelpMessage = "Set this token as the current token to use when performing Azure AD based authentication requests with PnP PowerShell")]
        public SwitchParameter SetAsCurrent;

        [Parameter(Mandatory = false, HelpMessage = "Optional credentials to use when retrieving the access token. If not present you need to connect first with Connect-PnPOnline.")]
        public PSCredential Credentials;

        [Parameter(Mandatory = false, HelpMessage = "Optional tenant URL to use when retrieving the access token. The Url should be in the shape of https://yourtenant.sharepoint.com. See examples for more info.")]
        public string TenantUrl;

        protected override void ProcessRecord()
        {

            Uri tenantUri = null;
            if (string.IsNullOrEmpty(TenantUrl) && SPOnlineConnection.CurrentConnection != null)
            {

                HttpClient client = new HttpClient();
                var uri = new Uri(SPOnlineConnection.CurrentConnection.Url);
                var uriParts = uri.Host.Split('.');
                if (uriParts[0].ToLower().EndsWith("-admin"))
                {
                    tenantUri =
                        new Uri(
                            $"{uri.Scheme}://{uriParts[0].ToLower().Replace("-admin", "")}.{string.Join(".", uriParts.Skip(1))}{(!uri.IsDefaultPort ? ":" + uri.Port : "")}");
                }
                else
                {
                    tenantUri = new Uri($"{uri.Scheme}://{uri.Authority}");
                }
            }
            else if (!string.IsNullOrEmpty(TenantUrl))
            {
                tenantUri = new Uri(TenantUrl);
            }
            else
            {
                throw new InvalidOperationException("Either a connection needs to be made by Connect-PnPOnline or TenantUrl and Credentials needs to be specified");
            }

            var tenantId = Microsoft.SharePoint.Client.TenantExtensions.GetTenantIdByUrl(tenantUri.ToString());

            string body;
            string response;
            var password = string.Empty;
            var username = string.Empty;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Credentials)))
            {
                password = EncryptionUtility.ToInsecureString(Credentials.Password);
                username = Credentials.UserName;
            }
            else if (SPOnlineConnection.CurrentConnection != null)
            {
                password = EncryptionUtility.ToInsecureString(SPOnlineConnection.CurrentConnection.PSCredential.Password);
                username = SPOnlineConnection.CurrentConnection.PSCredential.UserName;
            }
            else
            {
                throw new InvalidOperationException("Either a connection needs to be made by Connect-PnPOnline or Credentials needs to be specified");
            }

            if (!string.IsNullOrEmpty(Resource))
            {
                body = $"grant_type=password&client_id={ClientId}&username={username}&password={password}&resource={Resource}";
                response = HttpHelper.MakePostRequestForString($"https://login.microsoftonline.com/{tenantId}/oauth2/token", body, "application/x-www-form-urlencoded");
            }
            else
            {
                var scopes = string.Join(" ", Scopes);
                body = $"grant_type=password&client_id={ClientId}&username={username}&password={password}&scope={scopes}";
                response = HttpHelper.MakePostRequestForString($"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token", body, "application/x-www-form-urlencoded");
            }
            var json = JToken.Parse(response);
            var accessToken = json["access_token"].ToString();

            if (SetAsCurrent.IsPresent)
            {
                if (SPOnlineConnection.CurrentConnection != null)
                {
                    SPOnlineConnection.CurrentConnection.AccessToken = accessToken;
                }
                else
                {
                    throw new InvalidOperationException("-SetAsCurrent can only be used when connecting using Connect-PnPOnline");
                }
            }
            if (Decoded.IsPresent)
            {
                var decodedToken = new JwtSecurityToken(accessToken);
                WriteObject(decodedToken);
            }
            else
            {
                WriteObject(accessToken);
            }

        }
    }
}
#endif