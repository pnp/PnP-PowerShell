using Microsoft.SharePoint.Client;
using Newtonsoft.Json.Linq;
using OfficeDevPnP.Core.Utilities;
using System.Web;

namespace SharePointPnP.PowerShell.Commands.Base
{
#if !ONPREMISES
    internal static class TokenHandler
    {
        internal static string AcquireToken(string resource, string scope = null)
        {
            if(SPOnlineConnection.CurrentConnection == null)
            {
                return null;            
            }

            var tenantId = TenantExtensions.GetTenantIdByUrl(SPOnlineConnection.CurrentConnection.Url);

            if (tenantId == null) return null;

            string body = "";
            if (SPOnlineConnection.CurrentConnection.PSCredential != null)
            { 
                var clientId = "31359c7f-bd7e-475c-86db-fdb8c937548e";
                var username = SPOnlineConnection.CurrentConnection.PSCredential.UserName;
                var password = EncryptionUtility.ToInsecureString(SPOnlineConnection.CurrentConnection.PSCredential.Password);
                body = $"grant_type=password&client_id={clientId}&username={username}&password={password}&resource={resource}";
            }
            else if (!string.IsNullOrEmpty(SPOnlineConnection.CurrentConnection.ClientId) && !string.IsNullOrEmpty(SPOnlineConnection.CurrentConnection.ClientSecret))
            {
                var clientId = SPOnlineConnection.CurrentConnection.ClientId;
                var clientSecret = HttpUtility.UrlEncode(SPOnlineConnection.CurrentConnection.ClientSecret);
                body = $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}&resource={resource}";
            }
            else
            {
                throw new System.UnauthorizedAccessException("Specify PowerShell Credentials or AppId and AppSecret");
            }

            var response = HttpHelper.MakePostRequestForString($"https://login.microsoftonline.com/{tenantId}/oauth2/token", body, "application/x-www-form-urlencoded");
            try
            {
                var json = JToken.Parse(response);
                return json["access_token"].ToString();
            }
            catch
            {
                return null;
            }
        }
    }
#endif
}
