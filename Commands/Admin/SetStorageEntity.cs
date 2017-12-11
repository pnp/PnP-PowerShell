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
    [Cmdlet(VerbsCommon.Set, "PnPStorageEntity", SupportsShouldProcess = true)]
    [CmdletHelp(@"Set Storage Entities / Farm Properties.",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(Code = @"PS:> Set-PnPStorageEntity -Key MyKey -Value ""MyValue"" -Comment ""My Comment"" -Description ""My Description""", Remarks = "Sets an existing or adds a new storage entity / farm property", SortOrder = 1)]   
    public class SetPnPStorageEntity : PnPCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The key of the value to set.")]
        public string Key;

        [Parameter(Mandatory = true, HelpMessage = "The value to set.")]
        public string Value;

        [Parameter(Mandatory = true, HelpMessage = "The comment to set.")]
        public string Comment;

        [Parameter(Mandatory = true, HelpMessage = "The description to set.")]
        public string Description;

        protected override void ExecuteCmdlet()
        {          
            var appCatalogUri = ClientContext.Web.GetAppCatalog();
            using (var clonedContext = ClientContext.Clone(appCatalogUri))
            {
                clonedContext.Web.SetStorageEntity(Key, Value, Description, Comment);
                clonedContext.ExecuteQueryRetry();
            }
        }
    }
}
#endif