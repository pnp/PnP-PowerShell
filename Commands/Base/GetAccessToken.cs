#if !ONPREMISES
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsCommon.Get, "PnPAccessToken")]
    [CmdletHelp("Returns the current OAuth Access token",
        "Gets the OAuth 2.0 Access Token to consume the Microsoft Graph API",
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
       Code = "PS:> Get-PnPAccessToken",
       Remarks = "Gets the OAuth 2.0 Access Token to consume the Microsoft Graph API",
       SortOrder = 1)]
    [CmdletExample(
       Code = "PS:> Get-PnPAccessToken -Decoded",
       Remarks = "Gets the full OAuth 2.0 Token to consume the Microsoft Graph API",
       SortOrder = 2)]
    [Obsolete("Use Get-PnPGraphAccessToken instead")]
    public class GetPnPAccessToken : PnPGraphCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Returns the access token in a decoded manner")]
        public SwitchParameter Decoded;

        protected override void ExecuteCmdlet()
        {
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