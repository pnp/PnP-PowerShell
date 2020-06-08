using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SharePointPnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Contains a Graph JWT oAuth token
    /// </summary>
    public class GraphToken : GenericToken
    {
        /// <summary>
        /// The resource identifier for Microsoft Graph API tokens
        /// </summary>
        public const string ResourceIdentifier = "https://graph.microsoft.com";

        /// <summary>
        /// The name of the default scope
        /// </summary>
        private const string DefaultScope = ".default";

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
        /// <param name="tenant">Name of the tenant to acquire the token for (i.e. contoso.onmicrosoft.com). Required.</param>
        /// <param name="clientId">ClientId to use to acquire the token. Required.</param>
        /// <param name="certificate">Certificate to use to acquire the token. Required.</param>
        /// <returns><see cref="GraphToken"/> instance with the token</returns>
        public static GenericToken AcquireToken(string tenant, string clientId, X509Certificate2 certificate)
        {
            if (string.IsNullOrEmpty(tenant))
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }
            if (certificate == null)
            {
                throw new ArgumentNullException(nameof(certificate));
            }

            var app = ConfidentialClientApplicationBuilder.Create(clientId).WithAuthority($"{OAuthBaseUrl}{tenant}").WithCertificate(certificate).Build();
            var tokenResult = app.AcquireTokenForClient(new[] { $"{ResourceIdentifier}/{DefaultScope}" }).ExecuteAsync().GetAwaiter().GetResult();

            return new GraphToken(tokenResult.AccessToken);
        }

        /// <summary>
        /// Tries to acquire a Microsoft Graph Access Token
        /// </summary>
        /// <param name="tenant">Name of the tenant to acquire the token for (i.e. contoso.onmicrosoft.com). Required.</param>
        /// <param name="clientId">ClientId to use to acquire the token. Required.</param>
        /// <param name="clientSecret">Client Secret to use to acquire the token. Required.</param>
        /// <returns><see cref="GraphToken"/> instance with the token</returns>
        public static GenericToken AcquireToken(string tenant, string clientId, string clientSecret)
        {
            if (string.IsNullOrEmpty(tenant))
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            if (string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }
            if (string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }

            var app = ConfidentialClientApplicationBuilder.Create(clientId).WithAuthority($"{OAuthBaseUrl}{tenant}").WithClientSecret(clientSecret).Build();
            var tokenResult = app.AcquireTokenForClient(new[] { $"{ResourceIdentifier}/{DefaultScope}" }).ExecuteAsync().GetAwaiter().GetResult();

            return new GraphToken(tokenResult.AccessToken);
        }

        /// <summary>
        /// Tries to acquire a Microsoft Graph Access Token for the provided scopes interactively by allowing the user to log in
        /// </summary>
        /// <param name="clientId">ClientId to use to acquire the token. Required.</param>
        /// <param name="scopes">Array with scopes that should be requested access to. Required.</param>
        /// <returns><see cref="GraphToken"/> instance with the token</returns>
        public static GenericToken AcquireTokenInteractive(string clientId, string[] scopes)
        {
            if(string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }
            if(scopes == null || scopes.Length == 0)
            {
                throw new ArgumentNullException(nameof(scopes));
            }

            var app = PublicClientApplicationBuilder.Create(clientId).Build();
            var tokenResult = app.AcquireTokenInteractive(scopes.Select(s => $"{ResourceIdentifier}/{s}").ToArray()).ExecuteAsync().GetAwaiter().GetResult();

            return new GraphToken(tokenResult.AccessToken);
        }
    }
}
