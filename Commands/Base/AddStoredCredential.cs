#if NETSTANDARD2_0
using System.Management.Automation;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Enums;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsCommon.Add, "PnPStoredCredential")]
    [CmdletHelp("Adds a credential to the credential manager/keychain",
        "Returns a stored credential from the Windows Credential Manager",
        Category = CmdletHelpCategory.Base)]
    [CmdletExample(Code = "PS:> Get-PnPStoredCredential -Name O365",
        Remarks = "Returns the credential associated with the specified identifier",
        SortOrder = 1)]
    [CmdletExample(Code = "PS:> Get-PnPStoredCredential -Name testEnvironment -Type OnPrem",
        Remarks = "Gets the credential associated with the specified identifier from the credential manager and then will return a credential that can be used for on-premises authentication",
        SortOrder = 2)]
    public class AddStoredCredential : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The credential to set")]
        public string Name;

        [Parameter(Mandatory = true)]
        public string Username;

        [Parameter(Mandatory = true)]
        public string Password;

        [Parameter(Mandatory = false)]
        public SwitchParameter Overwrite;

        protected override void ProcessRecord()
        {
            Utilities.CredentialManager.AddCredential(Name, Username, Password, Overwrite.ToBool());
        }
    }
}
#endif