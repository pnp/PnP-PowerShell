using Microsoft.SharePoint.Client;
using Newtonsoft.Json.Linq;
using OfficeDevPnP.Core.Utilities;

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

            var clientId = "31359c7f-bd7e-475c-86db-fdb8c937548e";
            var username = SPOnlineConnection.CurrentConnection.PSCredential.UserName;
            var password = EncryptionUtility.ToInsecureString(SPOnlineConnection.CurrentConnection.PSCredential.Password);
            var body = $"grant_type=password&client_id={clientId}&username={username}&password={password}&resource={resource}";
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
