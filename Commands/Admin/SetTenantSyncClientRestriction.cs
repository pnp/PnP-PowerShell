#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using System.Management.Automation;
using System;
using System.Collections.Generic;
using Microsoft.Online.SharePoint.TenantManagement;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Set, "PnPTenantSyncClientRestriction", DefaultParameterSetName = ParameterAttribute.AllParameterSets)]
    [CmdletHelp(@"Sets organization-level sync client restriction properties",
        DetailedDescription = @"Sets organization-level sync client restriction properties such as BlockMacSync, OptOutOfGroveBlock, and DisableReportProblemDialog.

You must have the SharePoint Online admin or Global admin role to run the cmdlet.",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
        Code = @"PS:> Set-PnPTenantSyncClientRestriction -BlockMacSync $False",
        Remarks = @"This example blocks access to Mac sync clients for OneDrive file synchronization", SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-SPOTenantSyncClientRestriction  -ExcludedFileExtensions ""pptx;docx;xlsx""",
        Remarks = @"This example blocks syncing of PowerPoint, Word, and Excel file types using the new sync client (OneDrive.exe).", SortOrder = 2)]
    public class SetTenantSyncClientRestriction : PnPAdminCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Block Mac sync clients-- the Beta version and the new sync client (OneDrive.exe). The values for this parameter are True and False. The default value is False.")]
        public bool BlockMacSync;

        [Parameter(Mandatory = false, HelpMessage = "Specifies if the Report Problem Dialog is disabled or not.")]
        public bool DisableReportProblemDialog;

        [Parameter(Mandatory = false, HelpMessage = "Sets the domain GUID to add to the safe recipient list. Requires a minimum of 1 domain GUID. The maximum number of domain GUIDs allowed are 125.")]
        public List<Guid> DomainGuids;

        [Parameter(Mandatory = false, HelpMessage = "Enables the feature to block sync originating from domains that are not present in the safe recipients list.")]
        public bool Enable;

        [Parameter(Mandatory = false, HelpMessage = "Blocks certain file types from syncing with the new sync client (OneDrive.exe).")]
        public List<string> ExcludedFileExtensions;

        [Parameter(Mandatory = false, HelpMessage = "Controls whether or not a tenant's users can sync OneDrive for Business libraries with the old OneDrive for Business sync client. The valid values are OptOut, HardOptin, and SoftOptin.")]
        public string GrooveBlockOption;

        protected override void ExecuteCmdlet()
        {
            ClientContext.Load(Tenant);
            ClientContext.ExecuteQueryRetry();

            if (null != DomainGuids)
            {
                Tenant.AllowedDomainListForSyncClient = new List<Guid>(DomainGuids);
            }

            Tenant.BlockMacSync = BlockMacSync;
            Tenant.IsUnmanagedSyncClientForTenantRestricted = Enable;

            if (null != ExcludedFileExtensions)
            {
                Tenant.ExcludedFileExtensionsForSyncClient = ExcludedFileExtensions;
            }

            if (GrooveBlockOption == "OptOut")
            {
                Tenant.OptOutOfGrooveBlock = true;
                Tenant.OptOutOfGrooveSoftBlock = true;
            }
            else if (GrooveBlockOption == "HardOptIn")
            {
                Tenant.OptOutOfGrooveBlock = false;
                Tenant.OptOutOfGrooveSoftBlock = true;
            }
            else if (GrooveBlockOption == "SoftOptIn")
            {
                Tenant.OptOutOfGrooveBlock = true;
                Tenant.OptOutOfGrooveSoftBlock = false;
            }
            ClientContext.ExecuteQueryRetry();
        }
    }
}
#endif