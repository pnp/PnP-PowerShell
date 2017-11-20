#if !ONPREMISES
using System.Linq;
using System.Management.Automation;
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Remove, "PnPStorageEntity", SupportsShouldProcess = true)]
    [CmdletHelp(@"Remove Storage Entities / Farm Properties.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(Code = @"PS:> Remove-PnPStorageEntity -Key MyKey ", Remarks = "Removes an existing storage entity / farm property", SortOrder = 1)]   
    public class RemovePnPStorageEntity : PnPCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The key of the value to set.")]
        public string Key;

        protected override void ExecuteCmdlet()
        {          
            var appCatalogUri = ClientContext.Web.GetAppCatalog();
            using (var clonedContext = ClientContext.Clone(appCatalogUri))
            {
                clonedContext.Web.RemoveStorageEntity(Key);
                clonedContext.ExecuteQueryRetry();
            }
        }
    }
}
#endif