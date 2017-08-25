using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.ModernPages
{
    public abstract class PnPModernPageCmdlet : PnPWebCmdlet
    {

        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The name of the page or the page in-memory instance.")]
        public ClientSidePagePipeBind Identity;

    }
}
