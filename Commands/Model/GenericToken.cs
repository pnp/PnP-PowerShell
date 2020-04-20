using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeDevPnP.Core.Utilities;
using System;
using System.Linq;
using System.Web;

namespace SharePointPnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Contains a JWT oAuth token
    /// </summary>
    public class GenericToken
    {
        /// <summary>
        /// Token which can be used to access the API
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        /// <summary>
        /// Token that can be used to retrieve a new access token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; protected set; }

        /// <summary>
        /// Date and time at which the current access token will no longer be valid to be used
        /// </summary>
        public DateTime ExpiresOn { get; protected set; }

        /// <summary>
        /// The APIs being targeted (i.e. https://graph.microsoft.com)
        /// </summary>
        public string[] Audiences { get; protected set; }

        /// <summary>
        /// The roles being given to the token (i.e. Group.ReadWrite.All)
        /// </summary>
        public string[] Roles { get; protected set; }

        /// <summary>
        /// The parsed access token into JWT
        /// </summary>
        public System.IdentityModel.Tokens.Jwt.JwtSecurityToken ParsedToken { get; private set; }

        public Enums.TokenAudience TokenAudience { get; protected set; }

        /// <summary>
        /// Instantiates a new token
        /// </summary>
        /// <param name="accesstoken">Accesstoken of which to instantiate a new token</param>
        public GenericToken(string accesstoken)
        {
            if(string.IsNullOrWhiteSpace(accesstoken))
            {
                throw new ArgumentNullException(nameof(accesstoken));
            }

            ParsedToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(accesstoken);
            TokenAudience = Enums.TokenAudience.Other;
            AccessToken = accesstoken;

            ExpiresOn = ParsedToken.ValidTo.ToLocalTime();
            Audiences = ParsedToken.Audiences.ToArray();
            Roles = ParsedToken.Claims.Where(c => c.Type == "roles").Select(c => c.Value).ToArray();
        }

        /// <summary>
        /// Tries to acquire a generic Microsoft Identity V1 Token
        /// </summary>
        /// <param name="tenant">Name of the tenant to acquire the token for (i.e. contoso.onmicrosoft.com)</param>
        /// <param name="clientId">ClientId to use to acquire the token</param>
        /// <param name="username">Username to use to acquire the token</param>
        /// <param name="password">Password to use to acquire the token</param>
        /// <param name="resource">Resource to acquire the token for (i.e. AllSites.FullControl)</param>
        /// <returns></returns>
        public static GenericToken AcquireV1Token(string tenant, string clientId, string username, string password, string resource)
        {
            var body = $"grant_type=password&client_id={clientId}&username={HttpUtility.UrlEncode(username)}&password={HttpUtility.UrlEncode(password)}&resource={resource}";
            var response = HttpHelper.MakePostRequestForString($"https://login.microsoftonline.com/{tenant}/oauth2/token", body, "application/x-www-form-urlencoded");
            var json = JToken.Parse(response);
            var accessToken = json["access_token"].ToString();

            return new GenericToken(accessToken);
        }

        /// <summary>
        /// Tries to acquire a generic Microsoft Identity V2 Token
        /// </summary>
        /// <param name="tenant">Name of the tenant to acquire the token for (i.e. contoso.onmicrosoft.com)</param>
        /// <param name="clientId">ClientId to use to acquire the token</param>
        /// <param name="username">Username to use to acquire the token</param>
        /// <param name="password">Password to use to acquire the token</param>
        /// <param name="scopes">One or more scopes to acquire the token for (i.e. AllSites.FullControl)</param>
        /// <returns></returns>
        public static GenericToken AcquireV2Token(string tenant, string clientId, string username, string password, string[] scopes)
        {
            var body = $"grant_type=password&client_id={clientId}&username={HttpUtility.UrlEncode(username)}&password={HttpUtility.UrlEncode(password)}&scope={string.Join(" ", scopes)}";
            var response = HttpHelper.MakePostRequestForString($"https://login.microsoftonline.com/{tenant}/oauth2/v2.0/token", body, "application/x-www-form-urlencoded");
            var json = JToken.Parse(response);
            var accessToken = json["access_token"].ToString();

            return new GenericToken(accessToken);
        }
    }
}
