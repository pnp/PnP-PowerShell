#if !ONPREMISES
using System.Management.Automation;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;

namespace SharePointPnP.PowerShell.Commands.ManagementApi
{
    [Cmdlet(VerbsCommon.Get, "PnPManagementApiAccessToken", DefaultParameterSetName = ParameterSet_GETTOKEN)]
    [CmdletHelp("Gets an access token for the Office 365 Management API",
        Category = CmdletHelpCategory.ManagementApi,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPManagementApiAccessToken",
       Remarks = "Gets the OAuth 2.0 Access Token to consume the Microsoft Office Management API",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPManagementApiAccessToken -Decoded",
       Remarks = "Gets the full OAuth 2.0 Token to consume the Microsoft Office Management API",
       SortOrder = 2)]
    [CmdletExample(
       Code = "PS:> Get-PnPManagementApiAccessToken -TenantId $tenantId -ClientId $clientId -ClientSecret $clientSecret)",
       Remarks = "Retrieves access token for the Office 365 Management API",
       SortOrder = 3)]
    [CmdletExample(
       Code = "PS:> Connect-PnPOnline -AccessToken (Get-PnPManagementApiAccessToken -TenantId $tenantId -ClientId $clientId -ClientSecret $clientSecret)",
       Remarks = "Connects to the Office 365 Management API using an access token for the Office 365 Management API",
       SortOrder = 4)]
    public class GetManagementApiAccessToken : PnPOfficeManagementApiCmdlet
    {
        private const string ParameterSet_CONNECT = "Connect and get token";
        private const string ParameterSet_GETTOKEN = "Get the token from the active session";

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_CONNECT, HelpMessage = "The Tenant ID to connect to the Office 365 Management API")]
        public string TenantId;

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_CONNECT, HelpMessage = "The App\\Client ID of the app which gives you access to the Office 365 Management API")]
        public string ClientId;

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_CONNECT, HelpMessage = "The Client Secret of the app which gives you access to the Office 365 Management API")]
        public string ClientSecret;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_CONNECT, HelpMessage = "Returns the access token in a decoded manner")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_GETTOKEN, HelpMessage = "Returns the access token in a decoded manner")]
        public SwitchParameter Decoded;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSetName == ParameterSet_CONNECT)
            {
                // TODO KZ: Deal with the tenantid/clientid/clientsecret connect
            }

            if (Decoded.IsPresent)
            {
                WriteObject(Token.ParsedToken);
            }
            else
            {
                WriteObject(AccessToken);
            }
        }
    }
}
#endif