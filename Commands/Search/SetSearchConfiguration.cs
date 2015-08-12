using System;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Administration;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.Enums;
using Resources = OfficeDevPnP.PowerShell.Commands.Properties.Resources;

namespace OfficeDevPnP.PowerShell.Commands.Search
{
    [Cmdlet(VerbsCommon.Set, "SPOSearchConfiguration")]
    [CmdletHelp("Returns the search configuration", Category = "Search")]
    [CmdletExample(
        Code = @"PS:> Set-SPOSearchConfiguration -Configuration $config",
        Remarks = "Sets the search configuration for the current web",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-SPOSearchConfiguration -Configuration $config -Scope Site",
        Remarks = "Sets the search configuration for the current site collection",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Set-SPOSearchConfiguration -Configuration $config -Scope Subscription",
        Remarks = "Sets the search configuration for the current tenant",
        SortOrder = 3)]
    public class SetSearchConfiguration : SPOWebCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Configuration;

        [Parameter(Mandatory = false)]
        public SearchConfigurationScope Scope = SearchConfigurationScope.Web;

        protected override void ExecuteCmdlet()
        {
            switch (Scope)
            {
                case SearchConfigurationScope.Web:
                    {
                        this.SelectedWeb.SetSearchConfiguration(Configuration);
                        break;
                    }
                case SearchConfigurationScope.Site:
                    {
                        ClientContext.Site.SetSearchConfiguration(Configuration);
                        break;
                    }
                case SearchConfigurationScope.Subscription:
                    {
                        if (!ClientContext.Url.ToLower().Contains("-admin"))
                        {
                            throw new InvalidOperationException(Resources.CurrentSiteIsNoTenantAdminSite);
                        }

                        ClientContext.ImportSearchSettings(Configuration, SearchObjectLevel.SPSiteSubscription);
                        break;
                    }
            }
        }
    }
}
