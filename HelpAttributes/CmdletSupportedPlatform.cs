using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.CmdletHelpAttributes
{
    /// <summary>
    /// The list of supported platforms by these cmdlets.
    /// </summary>
    [Flags]
    public enum CmdletSupportedPlatform : int
    {
        All = 1,
        Online = 2,
        OnPremises = 4,
        SP2013 = 8,
        SP2016 = 16
    }
}
