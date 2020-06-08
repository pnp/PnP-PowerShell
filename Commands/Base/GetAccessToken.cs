using SharePointPnP.PowerShell.CmdletHelpAttributes;
#if NETSTANDARD2_1
using System.IdentityModel.Tokens.Jwt;
#else
using System.IdentityModel.Tokens.Jwt;
#endif
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsCommon.Get, "PnPAccessToken")]
    [CmdletHelp("Returns the current OAuth Access token",
        DetailedDescription = "Gets the OAuth 2.0 Access Token to consume the Microsoft Graph API. Doesn't work with all Connect-PnPOnline options.",
        Category = CmdletHelpCategory.Graph,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPAccessToken",
       Remarks = "Gets the OAuth 2.0 Access Token to consume the Microsoft Graph API",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPAccessToken -Decoded",
       Remarks = "Gets detailed information about the OAuth 2.0 Access Token that can be consumed to access the Microsoft Graph API",
       SortOrder = 2)]
    public class GetPnPAccessToken : PnPGraphCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Returns the details from the access token in a decoded manner")]
        public SwitchParameter Decoded;
        protected override void ExecuteCmdlet()
        {
            if (Decoded.IsPresent)
            {
                var decodedToken = new JwtSecurityToken(AccessToken);
                WriteObject(decodedToken);
            }
            else
            {
                WriteObject(AccessToken);
            }
        }
    }
}
