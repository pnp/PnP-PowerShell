#if !ONPREMISES
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Model;
using SharePointPnP.PowerShell.Commands.Properties;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Base
{
    /// <summary>
    /// Base class for all the PnP Microsoft Graph related cmdlets
    /// </summary>
    public abstract class PnPGraphCmdlet : PnPConnectedCmdlet
    {
        /// <summary>
        /// Returns an Access Token for the Microsoft Graph API, if available, otherwise NULL
        /// </summary>
        public GraphToken Token
        {
            get
            {
                // Collect the permission attributes to discover required roles
                var requiredRoleAttributes = (CmdletMicrosoftGraphApiPermission[])Attribute.GetCustomAttributes(GetType(), typeof(CmdletMicrosoftGraphApiPermission));
                var requiredRoles = new List<string>(requiredRoleAttributes.Length);
                foreach (var requiredRoleAttribute in requiredRoleAttributes)
                {
                    requiredRoles.Add(requiredRoleAttribute.ApiPermission.ToString().Replace("_", "."));
                }

                // Ensure we have an active connection
                if (SPOnlineConnection.CurrentConnection != null)
                {
                    // There is an active connection, try to get a Microsoft Graph Token on the active connection
                    if (SPOnlineConnection.CurrentConnection.TryGetToken(Enums.TokenAudience.MicrosoftGraph, requiredRoles.ToArray()) is GraphToken token)
                    {
                        // Microsoft Graph Access Token available, return it
                        return token;
                    }
                }

                // No valid Microsoft Graph Access Token available, throw an error
                ThrowTerminatingError(new ErrorRecord(new InvalidOperationException(string.Format(Resources.NoApiAccessToken, Enums.TokenAudience.MicrosoftGraph)), "NO_OAUTH_TOKEN", ErrorCategory.ConnectionError, null));
                return null;

            }
        }

        /// <summary>
        /// Returns an Access Token for Microsoft Graph, if available, otherwise NULL
        /// </summary>
        public string AccessToken => Token?.AccessToken;
    }
}
#endif