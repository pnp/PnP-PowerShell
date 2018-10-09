#if !ONPREMISES
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.Add, "PnPProvisioningSubSite", SupportsShouldProcess = true)]
    [CmdletHelp("Adds a provisioning sequence object to a provisioning site object",
        Category = CmdletHelpCategory.Provisioning, SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = @"PS:> Add-PnPProvisioningSubSite -Site $mysite -SubSite $mysubsite",
       Remarks = "Adds an existing subsite object to an existing hierarchy sequence site object",
       SortOrder = 1)]
    public class AddProvisioningSubSite : PSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The subsite to add")]
        public TeamNoGroupSubSite SubSite;

        [Parameter(Mandatory = true, HelpMessage = "The site to add the subsite to", ValueFromPipeline = true)]
        public SiteCollection Site;

        protected override void ProcessRecord()
        {
            if (Site.Sites.Cast<TeamNoGroupSubSite>().FirstOrDefault(s => s.Url == SubSite.Url) == null)
            {
                Site.Sites.Add(SubSite);
            }
            else
            {
                WriteError(new ErrorRecord(new Exception($"Site with URL {SubSite.Url} already exists in sequence"), "DUPLICATEURL", ErrorCategory.InvalidData, SubSite));
            }
        }
    }
}
#endif