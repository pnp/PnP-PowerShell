using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Collections.Generic;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using OfficeDevPnP.Core.Sites;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsCommon.Add, "PnPOffice365GroupToSite")]
    [CmdletHelp("Groupifies a classic team site by creating a group for it and connecting the site with the newly created group",
        DetailedDescription = "This command allows you to add an Office 365 Unified group to an existing classic site collection. It acts on the current site collection which you connected to with Connect-PnPOnline.",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.Sites)]
    [CmdletExample(
        Code = @"PS:> Add-PnPOffice365GroupToSite -Alias ""MyGroup"" -DisplayName = ""My new Group""",
        Remarks = @"This will add a group call MyGroup to the current site collection", SortOrder = 1)]
    public class AddOffice365GroupToSite : PnPCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Specifies the alias of the group. Cannot contain spaces.")]
        public string Alias;

        [Parameter(Mandatory = false, HelpMessage = @"The optional description of the group.")]
        public string Description;

        [Parameter(Mandatory = true, HelpMessage = @"The display name of the group.")]
        public string DisplayName;

        [Parameter(Mandatory = false, HelpMessage = @"Specifies the classification of the group.")]
        public string Classification;

        [Parameter(Mandatory = false,  HelpMessage = @"Specifies if the group is public. Defaults to false.")]
        public SwitchParameter IsPublic;

        protected override void ExecuteCmdlet()
        {
            TeamSiteCollectionGroupifyInformation groupifyInformation = new TeamSiteCollectionGroupifyInformation();
            groupifyInformation.Alias = Alias;
            groupifyInformation.Description = Description;
            groupifyInformation.DisplayName = DisplayName;
            groupifyInformation.IsPublic = IsPublic;
            groupifyInformation.Classification = Classification;

            var results = SiteCollection.GroupifyAsync(ClientContext, groupifyInformation);
            var returnedContext = results.GetAwaiter().GetResult();
            WriteObject(returnedContext.Url);
        }
    }
}