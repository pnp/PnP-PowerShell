using System.Management.Automation;
using PnP.PowerShell.CmdletHelpAttributes;
using System.Collections.Generic;

namespace PnP.PowerShell.Commands.Search
{
    [Cmdlet(VerbsCommon.Get, "PnPSiteSearchQueryResults", DefaultParameterSetName = "Limit")]
    [CmdletHelp("Executes a search query to retrieve indexed site collections",
        Category = CmdletHelpCategory.Search,
        OutputType = typeof(List<dynamic>))]
    [CmdletExample(
        Code = @"PS:> Get-PnPSiteSearchQueryResults",
        Remarks = "Returns the top 500 site collections indexed by SharePoint Search",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSiteSearchQueryResults -Query ""WebTemplate:STS""",
        Remarks = "Returns the top 500 site collections indexed by SharePoint Search which have are based on the STS (Team Site) template",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSiteSearchQueryResults -Query ""WebTemplate:SPSPERS""",
        Remarks = "Returns the top 500 site collections indexed by SharePoint Search which have are based on the SPSPERS (MySite) template, up to the MaxResult limit",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSiteSearchQueryResults -Query ""Title:Intranet*""",
        Remarks = "Returns the top 500 site collections indexed by SharePoint Search of which the title starts with the word Intranet",
        SortOrder = 4)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSiteSearchQueryResults -MaxResults 10",
        Remarks = "Returns the top 10 site collections indexed by SharePoint Search",
        SortOrder = 5)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSiteSearchQueryResults -All",
        Remarks = "Returns absolutely all site collections indexed by SharePoint Search",
        SortOrder = 6)]
    public class GetSiteSearchQueryResults : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0, HelpMessage = "Search query in Keyword Query Language (KQL) to execute to refine the returned sites. If omitted, all indexed sites will be returned.", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string Query = string.Empty;

        [Parameter(Mandatory = false, HelpMessage = "Search result item to start returning the results from. Useful for paging. Leave at 0 to return all results.", ParameterSetName = "Limit")]
        public int StartRow = 0;

        [Parameter(Mandatory = false, HelpMessage = "Maximum amount of search results to return. Default and max is 500 search results.", ParameterSetName = "Limit")]
        [ValidateRange(0, 500)]
        public int MaxResults = 500;

        [Parameter(Mandatory = false, HelpMessage = "Automatically page results until the end to get more than 500 sites. Use with caution!", ParameterSetName = "All")]
        public SwitchParameter All;

        protected override void ExecuteCmdlet()
        {
            var queryCmdLet = new SubmitSearchQuery();
            queryCmdLet.StartRow = StartRow;
            queryCmdLet.MaxResults = MaxResults;
            var query = "contentclass:STS_Site";
            if (!string.IsNullOrEmpty(Query))
            {
                query = query + " AND " + Query;
            }
            queryCmdLet.Query = query;

            queryCmdLet.SelectProperties = new[] {"Title","SPSiteUrl","Description","WebTemplate"};
            queryCmdLet.SortList = new System.Collections.Hashtable
            {
                { "SPSiteUrl", "ascending" }
            };
            queryCmdLet.RelevantResults = true;

            var res = queryCmdLet.Run();

            var dynamicList = new List<dynamic>();
            foreach (var row in res)
            {
                var obj = row as PSObject;                
                dynamicList.Add(
                    new
                    {
                        Title = obj.Properties["Title"]?.Value ?? "",
                        Url = obj.Properties["SPSiteUrl"]?.Value ?? "",
                        Description = obj.Properties["Description"]?.Value ?? "",
                        WebTemplate = obj.Properties["WebTemplate"]?.Value ?? ""
                    });
            }

            WriteObject(dynamicList, true);
        }
    }
}
