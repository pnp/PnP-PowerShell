using Microsoft.Identity.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Management.Automation;
using AuthenticationResult = Microsoft.Identity.Client.AuthenticationResult;
using ClientCredential = Microsoft.Identity.Client.ClientCredential;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet("Connect", "PnPMicrosoftGraph", DefaultParameterSetName = "Scope")]
    [CmdletHelp("Uses the Microsoft Authentication Library (Preview) to connect to Azure AD and to get an OAuth 2.0 Access Token to consume the Microsoft Graph API",
        Category = CmdletHelpCategory.Graph)]
    [CmdletExample(
       Code = "PS:> Connect-PnPMicrosoftGraph -Scopes $arrayOfScopes",
       Remarks = "Connects to Azure AD and gets and OAuth 2.0 Access Token to consume the Microsoft Graph API including the declared permission scopes. The available permission scopes are defined at the following URL: https://graph.microsoft.io/en-us/docs/authorization/permission_scopes",
       SortOrder = 1)]
    public class ConnectPnPMicrosoftGraph : PSCmdlet
    {
        private const string MSALPnPPowerShellClientId = "bb0c5778-9d5c-41ea-a4a8-8cd417b3ab71";
        private const string RedirectUri = "urn:ietf:wg:oauth:2.0:oob";
        private static readonly Uri AADLogin = new Uri("https://login.microsoftonline.com/");
        private static readonly string[] DefaultScope = new[] { "https://graph.microsoft.com/.default" };

        [Parameter(Mandatory = true, HelpMessage = "The array of permission scopes for the Microsoft Graph API.", ParameterSetName = "Scope")]
        public String[] Scopes;

        [Parameter(Mandatory = true, HelpMessage = "The client id of the app which gives you access to the Microsoft Graph API.", ParameterSetName = "AAD")]
        public string ClientId;
        [Parameter(Mandatory = true, HelpMessage = "The app key of the app which gives you access to the Microsoft Graph API.", ParameterSetName = "AAD")]
        public string AppKey;

        [Parameter(Mandatory = true, HelpMessage = "The AAD where the O365 app is registred. Eg.: contoso.com, or contoso.onmicrosoft.com.", ParameterSetName = "AAD")]
        public string AADDomain;

        protected override void ProcessRecord()
        {
            AuthenticationResult authenticationResult;
            if (Scopes != null)
            {
                PublicClientApplication clientApplication = new PublicClientApplication(MSALPnPPowerShellClientId);
                // Acquire an access token for the given scope
                authenticationResult = clientApplication.AcquireTokenAsync(Scopes).GetAwaiter().GetResult();
            }
            else
            {
                var credz = new ClientCredential(AppKey);
                var authority = new Uri(AADLogin, AADDomain).AbsoluteUri;
                ConfidentialClientApplication clientApplication = new ConfidentialClientApplication(authority, ClientId, RedirectUri, credz, null);
                authenticationResult = clientApplication.AcquireTokenForClient(DefaultScope, null).GetAwaiter().GetResult();
            }

            // Get back the Access Token and the Refresh Token
            PnPAzureADConnection.AuthenticationResult = authenticationResult;
        }
    }
}
