using Microsoft.Identity.Client;
using System.Security.Cryptography.X509Certificates;

namespace SharePointPnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Contains an Office 365 Management API JWT oAuth token
    /// </summary>
    public class OfficeManagementApiToken : GenericToken
    {
        /// <summary>
        /// Instantiates a new Office 365 Management API token
        /// </summary>
        /// <param name="accesstoken">Accesstoken of which to instantiate a new token</param>
        public OfficeManagementApiToken(string accesstoken) : base(accesstoken)
        {
            TokenAudience = Enums.TokenAudience.MicrosoftGraph;
        }

        /// <summary>
        /// Tries to acquire an Office 365 Management API Access Token
        /// </summary>
        /// <param name="tenant">Name of the tenant to acquire the token for (i.e. contoso.onmicrosoft.com)</param>
        /// <param name="clientId">ClientId to use to acquire the token</param>
        /// <param name="certificate">Certificate to use to acquire the token</param>
        /// <returns></returns>
        public static GenericToken AcquireToken(string tenant, string clientId, X509Certificate2 certificate)
        {
            var app = ConfidentialClientApplicationBuilder.Create(clientId).WithAuthority($"https://login.microsoftonline.com/{tenant}").WithCertificate(certificate).Build();
            var tokenResult = app.AcquireTokenForClient(new[] { "https://manage.office.com/.default" }).ExecuteAsync().GetAwaiter().GetResult();

            return new OfficeManagementApiToken(tokenResult.AccessToken);
        }
    }
}
