#if !ONPREMISES
using System;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;
using OfficeDevPnP.Core.Entities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;
using System.Threading.Tasks;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.New, "PnPSite")]
    [CmdletHelp("BETA: This cmdlet is using early release APIs. Notice that functionality and parameters can change. Creates a new site collection",
        OutputType = typeof(string),
        OutputTypeDescription = "Returns the url of the newly created site collection",
        DetailedDescription = @"The New-PnPSite cmdlet creates a new site collection for the current tenant. Currently only 'modern' sites like Communication Site and the Modern Team Site are supported. If you want to create a classic site, use New-PnPTenantSite.",
        Category = CmdletHelpCategory.TenantAdmin, SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
        Code = @"PS:> New-PnPSite -Title Contoso -Url https://tenant.sharepoint.com/sites/contoso",
        Remarks = @"This will create a new Communications Site collection with the title 'Contoso' and the url 'https://tenant.sharepoint.com/sites/contoso'",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> New-PnPSite -Title Contoso -Url https://tenant.sharepoint.com/sites/contoso -SiteDesign Showcase",
        Remarks = @"This will create a new Communications Site collection with the title 'Contoso' and the url 'https://tenant.sharepoint.com/sites/contoso'. It will use the 'Showcase' design for the site.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> New-PnPSite -Title Contoso -Url https://tenant.sharepoint.com/sites/contoso -SiteDesignId ae2349d5-97d6-4440-94d1-6516b72449ac",
        Remarks = @"This will create a new Communications Site collection with the title 'Contoso' and the url 'https://tenant.sharepoint.com/sites/contoso'. It will use the specified custom site design for the site.",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> New-PnPSite -Title Contoso -Url https://tenant.sharepoint.com/sites/contoso -Classification ""HBI""",
        Remarks = @"This will create a new Communications Site collection with the title 'Contoso' and the url 'https://tenant.sharepoint.com/sites/contoso'. The classification for the site will be set to ""HBI""",
        SortOrder = 4)]
    [CmdletExample(
        Code = @"PS:> New-PnPSite -Title Contoso -Url https://tenant.sharepoint.com/sites/contoso -AllowFileSharingForGuestUsers",
        Remarks = @"This will create a new Communications Site collection with the title 'Contoso' and the url 'https://tenant.sharepoint.com/sites/contoso'. File sharing for guest users will be enabled.",
        SortOrder = 5)]
    [CmdletExample(
        Code = @"PS:> New-PnPSite -Title Contoso -Alias contoso",
        Remarks = @"This will create a new Modern Team Site collection with the title 'Contoso' and the url 'https://tenant.sharepoint.com/sites/contoso'.",
        SortOrder = 6)]
    [CmdletExample(
        Code = @"PS:> New-PnPSite -Title Contoso -Alias contoso -IsPublic",
        Remarks = @"This will create a new Modern Team Site collection with the title 'Contoso' and the url 'https://tenant.sharepoint.com/sites/contoso' and sets the site to public.",
        SortOrder = 7)]
    public class NewSite : PnPCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = @"Specifies the title of the new site collection", ParameterSetName = "CommunicationBuiltInDesign")]
        [Parameter(Mandatory = true, HelpMessage = @"Specifies the title of the new site collection", ParameterSetName = "CommunicationCustomInDesign")]
        [Parameter(Mandatory = true, HelpMessage = @"Specifies the title of the new site collection", ParameterSetName = "TeamSite")]
        public string Title;

        [Parameter(Mandatory = true, HelpMessage = @"Specifies the full url of the new site collection", ParameterSetName = "CommunicationBuiltInDesign")]
        [Parameter(Mandatory = true, HelpMessage = @"Specifies the full url of the new site collection", ParameterSetName = "CommunicationCustomInDesign")]
        public string Url;

        [Parameter(Mandatory = true, HelpMessage = @"Specifies the alias of the new site collection", ParameterSetName = "TeamSite")]
        public string Alias;

        [Parameter(Mandatory = false, HelpMessage = @"Specifies the description of the new site collection", ParameterSetName = "CommunicationBuiltInDesign")]
        [Parameter(Mandatory = false, HelpMessage = @"Specifies the description of the new site collection", ParameterSetName = "CommunicationCustomInDesign")]
        [Parameter(Mandatory = false, HelpMessage = @"Specifies the description of the new site collection", ParameterSetName = "TeamSite")]
        public string Description;

        [Parameter(Mandatory = false, HelpMessage = @"Specifies the classification of the new site collection", ParameterSetName = "CommunicationBuiltInDesign")]
        [Parameter(Mandatory = false, HelpMessage = @"Specifies the classification of the new site collection", ParameterSetName = "CommunicationCustomInDesign")]
        [Parameter(Mandatory = false, HelpMessage = @"Specifies the classification of the new site collection", ParameterSetName = "TeamSite")]
        public string Classification;

        [Parameter(Mandatory = false, HelpMessage = @"Specifies the classification of the new site collection", ParameterSetName = "CommunicationBuiltInDesign")]
        [Parameter(Mandatory = false, HelpMessage = @"Specifies the classification of the new site collection", ParameterSetName = "CommunicationCustomInDesign")]
        public SwitchParameter AllowFileSharingForGuestUsers;

        [Parameter(Mandatory = false, HelpMessage = @"Specifies the site design of the new site collection. Defaults to 'Topic'", ParameterSetName = "CommunicationBuiltInDesign")]
        public OfficeDevPnP.Core.Sites.CommunicationSiteDesign SiteDesign = OfficeDevPnP.Core.Sites.CommunicationSiteDesign.Topic;

        [Parameter(Mandatory = true, HelpMessage = @"Specifies the site design id to use for the new site collection. If specified will override SiteDesign", ParameterSetName = "CommunicationCustomInDesign")]
        public GuidPipeBind SiteDesignId;

        [Parameter(Mandatory = false, HelpMessage = @"Specifies the language of the new site collection. Defaults to the current language of the web connected to.", ParameterSetName = "CommunicationBuiltInDesign")]
        [Parameter(Mandatory = false, HelpMessage = @"Specifies the language of the new site collection. Defaults to the current language of the web connected to.", ParameterSetName = "CommunicationCustomInDesign")]
        public uint Lcid;

        [Parameter(Mandatory = false, HelpMessage = @"Specifies if new site collection is public. Defaults to false.", ParameterSetName = "TeamSite")]
        public SwitchParameter IsPublic;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSetName.StartsWith("Communication"))
            {
                if (!MyInvocation.BoundParameters.ContainsKey("Lcid"))
                {
                    ClientContext.Web.EnsureProperty(w => w.Language);
                    Lcid = ClientContext.Web.Language;
                }
                var creationInformation = new OfficeDevPnP.Core.Sites.CommunicationSiteCollectionCreationInformation();
                creationInformation.Title = Title;
                creationInformation.Url = Url;
                creationInformation.Description = Description;
                creationInformation.Classification = Classification;
                creationInformation.AllowFileSharingForGuestUsers = AllowFileSharingForGuestUsers;
                creationInformation.Lcid = Lcid;
                if (ParameterSetName == "CommunicationCustomInDesign")
                {
                    creationInformation.SiteDesignId = SiteDesignId.Id;
                }
                else
                {
                    creationInformation.SiteDesign = SiteDesign;
                }
                var results = ClientContext.CreateSiteAsync(creationInformation);
                var returnedContext = results.GetAwaiter().GetResult();
                WriteObject(returnedContext.Url);
            }
            else
            {
                var creationInformation = new OfficeDevPnP.Core.Sites.TeamSiteCollectionCreationInformation();
                creationInformation.DisplayName = Title;
                creationInformation.Alias = Alias;
                creationInformation.Classification = Classification;
                creationInformation.Description = Description;
                creationInformation.IsPublic = IsPublic;

                var results = ClientContext.CreateSiteAsync(creationInformation);
                var returnedContext = results.GetAwaiter().GetResult();
                WriteObject(returnedContext.Url);
            }
        }
    }
}
#endif