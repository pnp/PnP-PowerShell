using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Model.Teams
{
    public partial class TeamChannelMessage
    {
        public TeamChannelMessageBody Body { get; set; }
    }

    public class TeamChannelMessageBody
    {
        public string Content { get; set; }
    }
}
