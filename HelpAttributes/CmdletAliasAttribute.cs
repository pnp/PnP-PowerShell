using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.CmdletHelpAttributes
{
    public class CmdletAliasAttribute
    {
        private string _alias;
        public CmdletAliasAttribute(string alias)
        {
            _alias = alias;
        }
    }
}
