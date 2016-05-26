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
        public int ItemCacheTimeout { get; set; }

        [Parameter()]
        public int WebCacheTimeout { get; set; }

        [Parameter()]
        public ClientRuntimeContext Context { get; set; }

    }
}