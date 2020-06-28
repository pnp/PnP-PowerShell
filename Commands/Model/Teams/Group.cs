using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Model.Teams
{
    public class Group
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string MailNickname { get; set; }
        public string Description { get; set; }
        public GroupVisibility Visibility { get; set; }
    }
}
