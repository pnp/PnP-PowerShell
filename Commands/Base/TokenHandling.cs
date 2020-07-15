using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Utilities;
using System.Text.Json;
using System.Web;

namespace PnP.PowerShell.Commands.Base
{
#if !ONPREMISES
    internal static class TokenHandler
    {
        internal static string AcquireToken(string resource, string scope = null)
        {
            if (PnPConnection.CurrentConnection == null)
            {
                return null;
            }

            var tenantId = TenantExtensions.GetTenantIdByUrl(PnPConnection.CurrentConnection.Url);

            if (tenantId == null) return null;

            string body = "";
            if (PnPConnection.CurrentConnection.PSCredential != null)
            {
                var clientId = "31359c7f-bd7e-475c-86db-fdb8c937548e";
                var username = PnPConnection.CurrentConnection.PSCredential.UserName;
                var password = EncryptionUtility.ToInsecureString(PnPConnection.CurrentConnection.PSCredential.Password);
                body = $"grant_type=password&client_id={clientId}&username={username}&password={password}&resource={resource}";
            }
            else if (!string.IsNullOrEmpty(PnPConnection.CurrentConnection.ClientId) && !string.IsNullOrEmpty(PnPConnection.CurrentConnection.ClientSecret))
            {
                var clientId = PnPConnection.CurrentConnection.ClientId;
                var clientSecret = HttpUtility.UrlEncode(PnPConnection.CurrentConnection.ClientSecret);
                body = $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}&resource={resource}";
            }
            else
            {
                throw new System.UnauthorizedAccessException("Specify PowerShell Credentials or AppId and AppSecret");
            }

            var response = HttpHelper.MakePostRequestForString($"https://login.microsoftonline.com/{tenantId}/oauth2/token", body, "application/x-www-form-urlencoded");
            try
            {
                using (var jdoc = JsonDocument.Parse(response))
                {
                    return jdoc.RootElement.GetProperty("access_token").GetString();
                }
            }
            catch
            {
                return null;
            }
        }
    }
#endif
}
