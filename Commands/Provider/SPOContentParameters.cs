using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provider
{
    public class SPOContentParameters
    {
        [Parameter()]
        public SwitchParameter IsBinary { get; set; }
    }
}