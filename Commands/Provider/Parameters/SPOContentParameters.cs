using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provider.Parameters
{
    public class SPOContentParameters
    {
        [Parameter(HelpMessage = "Handle the input/output as binary data")]
        public SwitchParameter IsBinary { get; set; }
    }
}