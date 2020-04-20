using SharePointPnP.PowerShell.Commands.Properties;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Base
{
    /// <summary>
    /// Base class for all the PnP Microsoft Graph related cmdlets
    /// </summary>
    public abstract class PnPGraphCmdlet : BasePSCmdlet
    {
        /// <summary>
        /// Returns an Access Token for Microsoft Graph, if available, otherwise NULL
        /// </summary>
        public string AccessToken
        {
            get
            {
#if ONPREMISES
                // Graph is not supported for on-premises
                return null;
#else
                // Ensure we have an active connection
                if(SPOnlineConnection.CurrentConnection != null)
                {
                    // There is an active connection, try to get a Microsoft Graph Token on the active connection
                    var graphAccessToken = SPOnlineConnection.CurrentConnection.TryGetAccessToken(Enums.TokenAudience.MicrosoftGraph);

                    if(graphAccessToken != null)
                    {
                        // Microsoft Graph Access Token available, return it
                        return graphAccessToken;
                    }
                }

                // No valid Microsoft Graph Access Token available, throw an error
                ThrowTerminatingError(new ErrorRecord(new InvalidOperationException(Resources.NoAzureADAccessToken), "NO_OAUTH_TOKEN", ErrorCategory.ConnectionError, null));
                return null;
#endif
            }
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected virtual void ExecuteCmdlet()
        { }

        protected override void ProcessRecord()
        {
            ExecuteCmdlet();
        }
    }
}
