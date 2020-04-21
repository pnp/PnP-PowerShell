using Microsoft.Identity.Client;
using System.Security.Cryptography.X509Certificates;

namespace SharePointPnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Contains a Graph JWT oAuth token
    /// </summary>
    public class GraphToken : GenericToken
    {
        /// <summary>
        /// The default scope to request when retrieving a token
        /// </summary>
        private const string DefaultScope = "https://graph.microsoft.com/.default";

        /// <summary>
        /// The base URL to request a token from
        /// </summary>
        private const string OAuthBaseUrl = "https://login.microsoftonline.com/";

        /// <summary>
        /// Instantiates a new Graph token
        /// </summary>
        /// <param name="accesstoken">Accesstoken of which to instantiate a new token</param>
        public GraphToken(string accesstoken) : base(accesstoken)
        {
            TokenAudience = Enums.TokenAudience.MicrosoftGraph;
        }

        /// <summary>
        /// Tries to acquire a Microsoft Graph Access Token
        /// </summary>
        /// <param name="tenant">Name of the tenant to acquire the token for (i.e. contoso.onmicrosoft.com)</param>
        /// <param name="clientId">ClientId to use to acquire the token</param>
        /// <param name="certificate">Certificate to use to acquire the token</param>
        /// <returns><see cref="GraphToken"/> instance with the token</returns>
        public static GenericToken AcquireToken(string tenant, string clientId, X509Certificate2 certificate)
        {
            var app = ConfidentialClientApplicationBuilder.Create(clientId).WithAuthority($"{OAuthBaseUrl}{tenant}").WithCertificate(certificate).Build();
            var tokenResult = app.AcquireTokenForClient(new[] { DefaultScope }).ExecuteAsync().GetAwaiter().GetResult();

            return new GraphToken(tokenResult.AccessToken);
        }

        /// <summary>
        /// Tries to acquire a Microsoft Graph Access Token
        /// </summary>
        /// <param name="tenant">Name of the tenant to acquire the token for (i.e. contoso.onmicrosoft.com)</param>
        /// <param name="clientId">ClientId to use to acquire the token</param>
        /// <param name="clientSecret">Client Secret to use to acquire the token</param>
        /// <returns><see cref="GraphToken"/> instance with the token</returns>
        public static GenericToken AcquireToken(string tenant, string clientId, string clientSecret)
        {
            var app = ConfidentialClientApplicationBuilder.Create(clientId).WithAuthority($"{OAuthBaseUrl}{tenant}").WithClientSecret(clientSecret).Build();
            var tokenResult = app.AcquireTokenForClient(new[] { DefaultScope }).ExecuteAsync().GetAwaiter().GetResult();

            return new GraphToken(tokenResult.AccessToken);
        }
    }
}
