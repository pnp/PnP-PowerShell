#if !ONPREMISES
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.ALM;
using System;

namespace SharePointPnP.PowerShell.Commands.Base.PipeBinds
{
    public sealed class AppMetadataPipeBind
    {
        private readonly AppMetadata _appMetadata;
        private readonly Guid _id;

        public AppMetadataPipeBind(AppMetadata metadata)
        {
            _appMetadata = metadata;
        }


        public AppMetadataPipeBind(Guid guid)
        {
            _id = guid;
        }

        public AppMetadataPipeBind(string id)
        {
            _id = Guid.Parse(id);
        }

        public Guid GetId()
        {
            if (_appMetadata != null)
            {
                return _appMetadata.Id;
            }
            else
            {
                return _id;
            }
        }
    }

}
#endif