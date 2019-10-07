using System;
using Microsoft.SharePoint.Client;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class ProvisioningConfigurationPipeBind
    {
        string value;

        public ProvisioningConfigurationPipeBind(string str)
        {
            value = str;
        }

        internal string GetContents(string currentFileSystemLocation)
        {
            try
            {
                if (!System.IO.Path.IsPathRooted(value))
                {
                    value = System.IO.Path.Combine(currentFileSystemLocation, value);
                }
                if (System.IO.File.Exists(value))
                {
                    return System.IO.File.ReadAllText(value);
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                return value;
            }
        }
    }
}
