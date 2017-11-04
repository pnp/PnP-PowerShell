using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.CmdletHelpAttributes
{
    [AttributeUsage(AttributeTargets.Field,
                    AllowMultiple = false)]
    public class PnPParameterAttribute : Attribute
    {
        public int Order { get; set; }
    }
}
