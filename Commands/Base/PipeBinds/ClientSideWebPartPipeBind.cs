#if !ONPREMISES
using OfficeDevPnP.Core.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public class ClientSideWebPartPipeBind
    {
        private readonly Guid _instanceid;
        private readonly string _title;

        public ClientSideWebPartPipeBind(Guid guid)
        {
            _instanceid = guid;
        }

        public ClientSideWebPartPipeBind(string instanceid)
        {
            if (!Guid.TryParse(instanceid, out _instanceid))
            {
                _title = instanceid;
            }
        }

        public Guid InstanceId => _instanceid;

        public string Title => _title;

        public ClientSideWebPartPipeBind()
        {
            _instanceid = Guid.Empty;
            _title = string.Empty;
        }

        public List<ClientSideWebPart> GetWebPart(ClientSidePage page)
        {
            if (page == null)
            {
                throw new ArgumentException(nameof(page));
            }
            if (!string.IsNullOrEmpty(_title))
            {
                return page.Controls.Where(c => c.GetType() == typeof(ClientSideWebPart) && ((ClientSideWebPart)c).Title.Equals(_title, StringComparison.InvariantCultureIgnoreCase)).Cast<ClientSideWebPart>().ToList();
            }
            return page.Controls.Where(c => c.GetType() == typeof(ClientSideWebPart) && c.InstanceId == _instanceid).Cast<ClientSideWebPart>().ToList();
        }
    }
}
#endif