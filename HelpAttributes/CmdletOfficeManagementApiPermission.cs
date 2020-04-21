using System;
using System.Runtime.Serialization;

namespace SharePointPnP.PowerShell.CmdletHelpAttributes
{
    /// <summary>
    /// Defines the supported API permissions for the Office Management Api configurable in Azure Active Directory
    /// </summary>
    public enum OfficeManagementApiPermission : short
    {
        [EnumMember(Value = "ActivityFeed.Read")]
        ActivityFeed_Read = 0
    }

    /// <summary>
    /// Add this attribute on a cmdlet class in order to provide the Api permission needed to execute the cmdlet
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class CmdletOfficeManagementApiPermissionAttribute : Attribute
    {
        /// <summary>
        /// The specific permission that is needed
        /// </summary>
        public OfficeManagementApiPermission ApiPermission { get; set; }

        /// <summary>
        /// Constructs a new ApiPermissionAttribute
        /// </summary>
        /// <param name="apiPermission">Specific permission that is needed</param>
        public CmdletOfficeManagementApiPermissionAttribute(OfficeManagementApiPermission apiPermission)
        {
            ApiPermission = apiPermission;
        }
    }
}
