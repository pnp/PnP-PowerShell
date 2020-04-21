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
    /// Base class for all the PnP Microsoft Office Management API related cmdlets
    /// </summary>
    public abstract class PnPOfficeManagementApiCmdlet : BasePSCmdlet
    {
        /// <summary>
        /// Returns an Access Token for the Microsoft Office Management API, if available, otherwise NULL
        /// </summary>
        public OfficeManagementApiToken Token
        {
            get
            {
                // Collect the permission attributes to discover required roles
                var requiredRoleAttributes = (CmdletOfficeManagementApiPermissionAttribute[])Attribute.GetCustomAttributes(GetType(), typeof(CmdletOfficeManagementApiPermissionAttribute));
                var requiredRoles = new List<string>(requiredRoleAttributes.Length);
                foreach(var requiredRoleAttribute in requiredRoleAttributes)
                {
                    requiredRoles.Add(requiredRoleAttribute.ApiPermission.ToString().Replace("_", "."));
                }

                // Ensure we have an active connection
                if (SPOnlineConnection.CurrentConnection != null)
                {
                    // There is an active connection, try to get a Microsoft Office Management API Token on the active connection
                    if (SPOnlineConnection.CurrentConnection.TryGetToken(Enums.TokenAudience.OfficeManagementApi, requiredRoles.ToArray()) is OfficeManagementApiToken token)
                    {
                        // Microsoft Office Management API Access Token available, return it
                        return token;
                    }
                }

                // No valid Microsoft Office Management API Access Token available, throw an error
                ThrowTerminatingError(new ErrorRecord(new InvalidOperationException(string.Format(Resources.NoApiAccessToken, Enums.TokenAudience.OfficeManagementApi)), "NO_OAUTH_TOKEN", ErrorCategory.ConnectionError, null));
                return null;
            }
        }

        /// <summary>
        /// Returns an Access Token for the Microsoft Office Management API, if available, otherwise NULL
        /// </summary>
        public string AccessToken => Token?.AccessToken;

        /// <summary>
        /// Root URL to the Office 365 Management API
        /// </summary>
        protected string ApiRootUrl => $"https://manage.office.com/api/v1.0/{Token.TenantId}/";

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