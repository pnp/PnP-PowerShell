#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.Online.SharePoint.TenantManagement;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Model
{
    public class SPOTenantSyncClientRestriction
    {
        public SPOTenantSyncClientRestriction(Tenant tenant)
        {
            this.allowedDomainList = new List<Guid>(tenant.AllowedDomainListForSyncClient);
            this.blockMacSync = tenant.BlockMacSync;
            this.excludedFileExtensions = new List<string>(tenant.ExcludedFileExtensionsForSyncClient);
            this.optOutOfGrooveBlock = tenant.OptOutOfGrooveBlock;
            this.optOutOfGrooveSoftBlock = tenant.OptOutOfGrooveSoftBlock;
            this.optOutOfGrooveSoftBlock = tenant.OptOutOfGrooveSoftBlock;
            this.disableReportProblemDialog = tenant.DisableReportProblemDialog;
            this.tenantRestrictionEnabled = tenant.IsUnmanagedSyncClientForTenantRestricted;
        }

        public bool BlockMacSync => blockMacSync;

        public List<Guid> AllowedDomainList => allowedDomainList;

        public List<string> ExcludedFileExtensionsForSyncClient => excludedFileExtensions;

        public bool OptOutOfGrooveBlock => optOutOfGrooveBlock;

        public bool OptOutOfGrooveSoftBlock => optOutOfGrooveSoftBlock;

        public bool DisableReportProblemDialog => disableReportProblemDialog;

        public bool TenantRestrictionEnabled => tenantRestrictionEnabled;

        private bool blockMacSync;

        private List<Guid> allowedDomainList;

        private List<string> excludedFileExtensions;

        private bool optOutOfGrooveBlock;

        private bool optOutOfGrooveSoftBlock;

        private bool disableReportProblemDialog;

        private bool tenantRestrictionEnabled;

    }
}
#endif