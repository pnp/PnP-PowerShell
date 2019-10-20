#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Query;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.Admin
{
    [Cmdlet(VerbsCommon.Get, "PnPHubChildSite")]
    [CmdletHelp(@"Retrieves all sites linked to a specific hub site",
        "Retrieves all sites linked to a specific hub site by leveraging SharePoint Search. This means that the account under which you run this command must have access to all of the SharePoint sites referincing to the hub or they will not be returned",
        Category = CmdletHelpCategory.TenantAdmin,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(Code = @"PS:> Get-PnPHubChildSite -Identity https://contoso.sharepoint.com/sites/myhubsite", Remarks = "Returns the sites having configured the provided hub site as their hub site", SortOrder = 1)]
    public class GetHubChildSite : PnPAdminCmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, HelpMessage = "The URL of the hubsite for which to receive the sites refering to it")]
        public HubSitePipeBind Identity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If provided, SharePoint search will not be used to return the child sites. This will be much slower but will not require the account under which you execute this command to have access to all sites which refer to the provided hub site. It also will not take some time before new sites will be returned as they will not need to be indexed by search first. If you provide this flag, it will iterate through all site collections which will be way slower but doesn't require access rights to the sites nor waiting for them to be indexed by SharePoint Search.")]
        public SwitchParameter DoNotUseSearch { get; set; } = false;

        [Parameter(Mandatory = false, HelpMessage = "If provided, the result will include the hub site itself along with its child sites. If omitted, it will only return the child sites pointing to the hub and not the hub site itself.")]
        public SwitchParameter IncludeHubSite { get; set; } = false;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the name of the client which issued the query to SharePoint Search. Only used if the flag " + nameof(DoNotUseSearch) + " has been provided.", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string ClientType = "ContentSearchLow";

        protected override void ExecuteCmdlet()
        {
            HubSiteProperties hubSiteProperties;
            try
            {
                hubSiteProperties = Identity.GetHubSite(Tenant);
                ClientContext.Load(hubSiteProperties, h => h.ID);
                ClientContext.ExecuteQueryRetry();
            }
            catch (ServerException ex)
            {
                if(ex.ServerErrorTypeName.Equals("System.IO.FileNotFoundException"))
                {
                    throw new ArgumentException(Resources.SiteNotFound, nameof(Identity));
                }

                throw ex;
            }

            // Get the ID of the hubsite for which we need to find child sites
            var hubSiteId = hubSiteProperties.ID;

            if (DoNotUseSearch)
            {
                // Retrieve all the site collections and then one by one check if they're connected to the provided hub site
                SPOSitePropertiesEnumerableFilter filter = new SPOSitePropertiesEnumerableFilter()
                {
                    IncludePersonalSite = PersonalSiteFilter.UseServerDefault,
                    IncludeDetail = false,
                    Filter = null
                };

                SPOSitePropertiesEnumerable sitesList = null;
                var sites = new List<SiteProperties>();
                do
                {
                    sitesList = Tenant.GetSitePropertiesFromSharePointByFilters(filter);
                    ClientContext.Load(sitesList);
                    ClientContext.ExecuteQueryRetry();

                    foreach(var site in sitesList)
                    {
                        var siteInfo = Tenant.GetSiteByUrl(site.Url);                        
                        ClientContext.Load(siteInfo);
                        ClientContext.ExecuteQueryRetry();

                        if(siteInfo.HubSiteId == hubSiteId && (IncludeHubSite || !Identity.Url.Equals(site.Url, System.StringComparison.CurrentCultureIgnoreCase)))
                        {
                            WriteObject(site.Url);
                        }
                    }

                    filter.StartIndex = sitesList.NextStartIndexFromSharePoint;
                } while (!string.IsNullOrWhiteSpace(sitesList.NextStartIndexFromSharePoint));

                WriteObject(sites, true);
            }
            else
            {
                // Use search to get all sited having managed property DepartmentId set to the provided HubSiteId
                var keywordQuery = new KeywordQuery(ClientContext);
                keywordQuery.QueryText = string.Concat("DepartmentId:{", hubSiteId, "} AND (contentclass=STS_Site)");
                keywordQuery.ClientType = ClientType;
                keywordQuery.SelectProperties.Add("DepartmentId");
                keywordQuery.SelectProperties.Add("SiteId");
                keywordQuery.SelectProperties.Add("Path");

                var searchExec = new SearchExecutor(ClientContext);
                var results = searchExec.ExecuteQuery(keywordQuery);
                ClientContext.ExecuteQueryRetry();

                foreach (ResultTable resultTable in results.Value)
                {
                    if (resultTable.TableType == "RelevantResults")
                    {
                        foreach (var resultRow in resultTable.ResultRows)
                        {
                            var siteUrl = resultRow["Path"];

                            if (siteUrl != null && (IncludeHubSite || !siteUrl.ToString().Equals(Identity.Url, System.StringComparison.CurrentCultureIgnoreCase)))
                            {
                                WriteObject(siteUrl);
                            }
                        }
                    }
                }
            }
        }
    }
}
#endif