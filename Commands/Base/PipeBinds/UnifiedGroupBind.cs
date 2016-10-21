using OfficeDevPnP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public class UnifiedGroupBind
    {
        private readonly UnifiedGroupEntity _group;
        private readonly String _groupId;
        private readonly String _displayName;

        public UnifiedGroupBind()
        {
        }

        public UnifiedGroupBind(UnifiedGroupEntity group)
        {
            _group = group;
        }

        public UnifiedGroupBind(String input)
        {
            Guid idValue;
            if (Guid.TryParse(input, out idValue))
            {
                _groupId = input;
            }
            else
            {
                _displayName = input;
            }
        }

        public UnifiedGroupEntity Group
        {
            get
            {
                return (_group);
            }
        }

        public String DisplayName
        {
            get
            {
                return (_displayName);
            }
        }

        public String GroupId
        {
            get
            {
                return (_groupId);
            }
        }
    }
}
