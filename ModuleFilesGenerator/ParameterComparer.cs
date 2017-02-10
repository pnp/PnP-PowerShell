using System.Collections.Generic;
using SharePointPnP.PowerShell.ModuleFilesGenerator.Model;

namespace SharePointPnP.PowerShell.ModuleFilesGenerator
{
    internal class ParameterComparer : IEqualityComparer<CmdletParameterInfo>
    {
        public bool Equals(CmdletParameterInfo x, CmdletParameterInfo y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(CmdletParameterInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }

}