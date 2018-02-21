#if !ONPREMISES
using OfficeDevPnP.Core.Sites;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsDiagnostic.Test, "PnPOffice365GroupAlias")]
    [CmdletHelp("Tests if a given alias is free to be used",
        DetailedDescription = "This command allows you to test if a provided alias is free to be used as part of connecting an Office 365 Unified group to an existing classic site collection.",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.Sites)]
    [CmdletExample(
        Code = @"PS:> Test-PnPOffice365GroupAlias -Alias ""MyGroup""",
        Remarks = @"This will test if the alias MyGroup can be used", SortOrder = 1)]
    public class AddOffice365GroupToSite : PnPCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "Specifies the alias of the group. Cannot contain spaces.")]
        public string Alias;

        protected override void ExecuteCmdlet()
        {
            var results = SiteCollection.AliasExistsAsync(ClientContext, Alias);
            var returnedBool = results.GetAwaiter().GetResult();
            WriteObject(returnedBool);
        }
    }
}
#endif