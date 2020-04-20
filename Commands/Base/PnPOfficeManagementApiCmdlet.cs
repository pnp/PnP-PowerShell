#if !ONPREMISES
using SharePointPnP.PowerShell.Commands.Model;
using SharePointPnP.PowerShell.Commands.Properties;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Base
{
    /// <summary>
    /// Base class for all the PnP Microsoft Office Management API related cmdlets
    /// </summary>
    public abstract class PnPOfficeManagementApiCmdlet : BasePSCmdlet
    {
        /// <summary>
        /// String array with roles that would be required to execute the cmdlet. If NULL, no specific roles will be validated.
        /// </summary>
        protected virtual string[] RequiredRoles { get; set; }

        /// <summary>
        /// Returns an Access Token for the Microsoft Office Management API, if available, otherwise NULL
        /// </summary>
        public OfficeManagementApiToken Token
        {
            get
            {
                // Ensure we have an active connection
                if (SPOnlineConnection.CurrentConnection != null)
                {
                    // There is an active connection, try to get a Microsoft Office Management API Token on the active connection
                    if (SPOnlineConnection.CurrentConnection.TryGetToken(Enums.TokenAudience.OfficeManagementApi, RequiredRoles) is OfficeManagementApiToken token)
                    {
                        // Microsoft Office Management API Access Token available, return it
                        return token;
                    }
                }

                // No valid Microsoft Office Management API Access Token available, throw an error
                ThrowTerminatingError(new ErrorRecord(new InvalidOperationException(Resources.NoAzureADAccessToken), "NO_OAUTH_TOKEN", ErrorCategory.ConnectionError, null));
                return null;

            }
        }

        /// <summary>
        /// Returns an Access Token for the Microsoft Office Management API, if available, otherwise NULL
        /// </summary>
        public string AccessToken => Token?.AccessToken;

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
#endif