using System.Management.Automation;
using System.Security.Cryptography.Pkcs;

namespace SharePointPnP.PowerShell.Commands.Provider
{
    public class SPOChildItemsParameters
    {
        [Parameter(HelpMessage = "Limit items collected when using list query")]
        public Limits Limit { get; set; }

        public enum Limits
        {
            Default,
            All = -1
        }
    }
}