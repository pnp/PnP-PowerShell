using System;
using System.Linq;
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.Commands.Enums;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.Base
{
    public abstract class PnPAdminCmdlet : PnPSharePointCmdlet
    {
        private Tenant _tenant;
        private Uri _baseUri;

        public Tenant Tenant
        {
            get
            {
                if (_tenant == null)
                {
                    _tenant = new Tenant(ClientContext);
                }
                return _tenant;
            }
        }

        public Uri BaseUri => _baseUri;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (PnPConnection.CurrentConnection == null)
            {
                throw new InvalidOperationException(Resources.NoSharePointConnection);
            }
            if (ClientContext == null)
            {
                throw new InvalidOperationException(Resources.NoSharePointConnection);
            }

            PnPConnection.CurrentConnection.CacheContext();

            if (PnPConnection.CurrentConnection.TenantAdminUrl != null &&
                (PnPConnection.CurrentConnection.ConnectionType == ConnectionType.O365 ||
                 PnPConnection.CurrentConnection.ConnectionType == ConnectionType.OnPrem))
            {
                var uri = new Uri(PnPConnection.CurrentConnection.Url);
                var uriParts = uri.Host.Split('.');
                if (uriParts[0].ToLower().EndsWith("-admin"))
                {
                    _baseUri =
                        new Uri(
                            $"{uri.Scheme}://{uriParts[0].ToLower().Replace("-admin", "")}.{string.Join(".", uriParts.Skip(1))}{(!uri.IsDefaultPort ? ":" + uri.Port : "")}");
                }
                else
                {
                    _baseUri = new Uri($"{uri.Scheme}://{uri.Authority}");
                }
                PnPConnection.CurrentConnection.CloneContext(PnPConnection.CurrentConnection.TenantAdminUrl);
            }
            else
            {
                Uri uri = new Uri(ClientContext.Url);
                var uriParts = uri.Host.Split('.');
                if (!uriParts[0].EndsWith("-admin") &&
                    PnPConnection.CurrentConnection.ConnectionType == ConnectionType.O365)
                {
                    _baseUri = new Uri($"{uri.Scheme}://{uri.Authority}");

                    var adminUrl = $"https://{uriParts[0]}-admin.{string.Join(".", uriParts.Skip(1))}";

                    PnPConnection.CurrentConnection.Context =
                        PnPConnection.CurrentConnection.CloneContext(adminUrl);
                }
                else if (PnPConnection.CurrentConnection.ConnectionType == ConnectionType.TenantAdmin)
                {
                    _baseUri =
                       new Uri(
                           $"{uri.Scheme}://{uriParts[0].ToLower().Replace("-admin", "")}{(uriParts.Length > 1 ? $".{string.Join(".", uriParts.Skip(1))}" : string.Empty )}{(!uri.IsDefaultPort ? ":" + uri.Port : "")}");

                }
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            PnPConnection.CurrentConnection.RestoreCachedContext(PnPConnection.CurrentConnection.Url);
        }
    }
}
