using System.Management.Automation;
using SharePointPnP.PowerShell.Commands.Utilities;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class CredentialPipeBind
    {
        private readonly PSCredential _psCredential;
        private readonly string _storedcredential;

        public CredentialPipeBind(PSCredential psCredential)
        {
            _psCredential = psCredential;
        }

        public CredentialPipeBind(string id)
        {
            _storedcredential = id;
        }

        public PSCredential Credential
        {
            get
            {
                if (_psCredential != null)
                {
                    return _psCredential;
                }
                else if (_storedcredential != null)
                {
                    var credentialsFromStore = CredentialManager.GetCredential(_storedcredential);
                    if(credentialsFromStore == null)
                    {
                        throw new PSArgumentException($"No credential store entry named '{_storedcredential}' exists", nameof(Credential));
                    }
                    return credentialsFromStore;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
