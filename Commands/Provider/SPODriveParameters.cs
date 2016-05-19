using System.Management.Automation;
using Microsoft.SharePoint.Client;

namespace SharePointPnP.PowerShell.Commands.Provider
{
    public class SPODriveParameters
    {
        [Parameter()]
        public Web Web { get; set; }

        [Parameter()]
        public string Url { get; set; }

        [Parameter()]
        public int CacheTimeout { get; set; }

        [Parameter()]
        public SwitchParameter UseCurrentSPOContext { get; set; }

    }
}