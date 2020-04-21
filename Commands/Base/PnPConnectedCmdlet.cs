using SharePointPnP.PowerShell.Commands.Properties;
using System;

namespace SharePointPnP.PowerShell.Commands.Base
{
    /// <summary>
    /// Base class for all the PnP Cmdlets which require a connection to have been made
    /// </summary>
    public abstract class PnPConnectedCmdlet : BasePSCmdlet
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            // Ensure there is an active connection
            if (PnPConnection.CurrentConnection == null)
            {
                throw new InvalidOperationException(Resources.NoConnection);
            }
        }
    }
}
