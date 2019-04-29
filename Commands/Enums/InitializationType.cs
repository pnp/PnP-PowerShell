using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Enums
{
    public enum InitializationType
    {
        Unknown,
        Credentials,
        Token,
        SPClientSecret,
        AADNativeApp,
        AADAppOnly,
        InteractiveLogin,
        ADFS,
        DeviceLogin,
        Graph,
        GraphDeviceLogin,
        HighTrust
    }
}
