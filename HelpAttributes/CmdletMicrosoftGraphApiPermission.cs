using System;
using System.Runtime.Serialization;

namespace SharePointPnP.PowerShell.CmdletHelpAttributes
{
    /// <summary>
    /// Defines the supported API permissions for the Microsoft Graph Api configurable in Azure Active Directory
    /// </summary>
    public enum MicrosoftGraphApiPermission : short
    {
        [EnumMember(Value = "Group.Read.All")]
        Group_Read_All,

        [EnumMember(Value = "Group.ReadWrite.All")]
        Group_ReadWrite_All,

        [EnumMember(Value = "Directory.ReadWrite.All")]
        Directory_ReadWrite_All
    }

    /// <summary>
    /// Add this attribute on a cmdlet class in order to provide the Api permission needed to execute the cmdlet
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class CmdletMicrosoftGraphApiPermission : Attribute
    {
        /// <summary>
        /// The specific permission that is needed
        /// </summary>
        public MicrosoftGraphApiPermission ApiPermission { get; set; }

        /// <summary>
        /// Constructs a new ApiPermissionAttribute
        /// </summary>
        /// <param name="apiPermission">Specific permission that is needed</param>
        public CmdletMicrosoftGraphApiPermission(MicrosoftGraphApiPermission apiPermission)
        {
            ApiPermission = apiPermission;
        }
    }
}
