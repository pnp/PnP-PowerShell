#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using System;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class TenantSiteDesignPipeBind
    {
        private readonly Guid _id;
        private readonly TenantSiteDesign _siteDesign;

        public TenantSiteDesignPipeBind(Guid guid)
        {
            _id = guid;
        }

        public TenantSiteDesignPipeBind(string id)
        {
            _id = new Guid(id);
        }

        public TenantSiteDesignPipeBind(TenantSiteDesign siteDesign)
        {
            _siteDesign = siteDesign;
        }

        public Guid Id
        {
            get
            {
                if(_siteDesign != null)
                {
                    return _siteDesign.Id;
                } else
                {
                    return _id;
                }
            }
        }

        public TenantSiteDesignPipeBind()
        {
            _id = Guid.Empty;
            _siteDesign = null;
        }

    }
}
#endif