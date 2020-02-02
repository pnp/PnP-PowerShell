#if !ONPREMISES
using OfficeDevPnP.Core.Sites;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsData.ConvertTo, "PnPCommSite")]
    [CmdletHelp("Enables the modern communication site experience on an existing site collection.",
        DetailedDescription = "This command will enable the communication site design package for the current classic, non-publishing, site. The site will be converted into a communication site",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.Sites)]
    [CmdletExample(
        Code = @"PS:> ConvertTo-PnPCommSite",
        Remarks = @"Enables the modern communication site experience on an existing site", SortOrder = 0)]
    [CmdletExample(
        Code = @"PS:> ConvertTo-PnPCommSite -DesignPackageId 6142d2a0-63a5-4ba0-aede-d9fefca2c767",
        Remarks = @"Enables the modern communication site experience on an existing site", SortOrder = 1)]
    public class ConvertToCommSite: PnPCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0, HelpMessage = "The id (guid) of the design package to apply: 96c933ac-3698-44c7-9f4a-5fd17d71af9e (Topic = default), 6142d2a0-63a5-4ba0-aede-d9fefca2c767 (Showcase) or f6cc5403-0d63-442e-96c0-285923709ffc (Blank)")]
        public string DesignPackageId;

        protected override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(DesignPackageId))
            {
                if (Guid.TryParse(DesignPackageId, out Guid designPackageIdGuid))
                {
                    SiteCollection.EnableCommunicationSite(ClientContext, designPackageIdGuid).GetAwaiter().GetResult();
                }
                else
                {
                    throw new Exception($"The provided design package id {DesignPackageId} is not a valid guid.");
                }
            }
            else
            {
                SiteCollection.EnableCommunicationSite(ClientContext).GetAwaiter().GetResult();
            }
        }
    }
}
#endif
