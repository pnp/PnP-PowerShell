#if !ONPREMISES
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsCommon.Set, "PnPSite")]
    [CmdletHelp("Sets Site Collection properties.",
        Category = CmdletHelpCategory.Sites,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSite -Classification ""HBI""",
        Remarks = "Sets the current site classification to HBI",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSite -Classification $null",
        Remarks = "Unsets the current site classification",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSite -DisableFlows",
        Remarks = "Disables Flows for this site",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Set-PnPSite -DisableFlows:$false",
        Remarks = "Enables Flows for this site",
        SortOrder = 3)]
    public class SetSite : PnPCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "The classification to set")]
        public string Classification;

        [Parameter(Mandatory = false, HelpMessage = "Disables flows for this site")]
        public SwitchParameter DisableFlows;

        [Parameter(Mandatory = false, HelpMessage = "Sets the logo if the site is modern team site. If you want to set the logo for a classic site, use Set-PnPWeb -SiteLogoUrl")]
        public string LogoFilePath;

        protected override void ExecuteCmdlet()
        {
            var executeQueryRequired = false;
            var site = ClientContext.Site;
            if (MyInvocation.BoundParameters.ContainsKey("Classification"))
            {
                site.Classification = Classification;
                executeQueryRequired = true;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DisableFlows"))
            {
                site.DisableFlows = DisableFlows;
                executeQueryRequired = true;
            }
            if (MyInvocation.BoundParameters.ContainsKey("LogoFilePath"))
            {
                var webTemplate = ClientContext.Web.EnsureProperty(w => w.WebTemplate);
                if (webTemplate == "GROUP")
                {
                    if (!System.IO.Path.IsPathRooted(LogoFilePath))
                    {
                        LogoFilePath = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, LogoFilePath);
                    }
                    if (System.IO.File.Exists(LogoFilePath))
                    {
                        var bytes = System.IO.File.ReadAllBytes(LogoFilePath);
                        var mimeType = System.Web.MimeMapping.GetMimeMapping(LogoFilePath);
                        var result = OfficeDevPnP.Core.Sites.SiteCollection.SetGroupImage(ClientContext, bytes, mimeType).GetAwaiter().GetResult();
                    }
                    else
                    {
                        throw new System.Exception("Logo file does not exist");
                    }
                } else
                {
                    throw new System.Exception("Not an Office365 group enabled site.");
                }
            }
            if (executeQueryRequired)
            {
                ClientContext.ExecuteQueryRetry();
            }
        }
    }
}
#endif