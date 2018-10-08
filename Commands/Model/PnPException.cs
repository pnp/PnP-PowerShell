using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Model
{
    public class PnPException
    {
        public string Message;
        public string Stacktrace;
        public int ScriptLineNumber;
        public InvocationInfo InvocationInfo;
    }
}
