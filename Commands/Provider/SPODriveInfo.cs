using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.SharePoint.Client;

namespace SharePointPnP.PowerShell.Commands.Provider
{
    internal class SPODriveInfo : PSDriveInfo
    {
        public Web Web { get; set; }
        public string NormalizedRoot { get; set; }

        internal bool IsNotClonedContext { get; set; }
        internal int Timeout { get; set; }
        internal List<SPODriveCacheItem> CachedItems { get; set; }

        public SPODriveInfo(PSDriveInfo driveInfo) : base(driveInfo)
        {
            CachedItems = new List<SPODriveCacheItem>();
        }
    }
}