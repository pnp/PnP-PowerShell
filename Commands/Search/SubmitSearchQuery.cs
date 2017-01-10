using System;
using System.Collections;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Query;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Collections.Generic;
using System.Linq;

namespace SharePointPnP.PowerShell.Commands.Search
{
    [Cmdlet("Submit", "PnPSearchQuery")]
    [CmdletAlias("Submit-SPOSearchQuery")]
    [CmdletHelp("Executes an arbitrary search query against the SharePoint search index",
        Category = CmdletHelpCategory.Search,
        OutputType = typeof(List<dynamic>))]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchQuery -Query ""finance""",
        Remarks = "Returns the top 500 items with the term finance",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchQuery -Query ""Title:Intranet*"" -MaxResults 10",
        Remarks = "Returns the top 10 items indexed by SharePoint Search of which the title starts with the word Intranet",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchQuery -Query ""Title:Intranet*"" -AutoPaging $true",
        Remarks = "Returns absolutely all items indexed by SharePoint Search of which the title starts with the word Intranet",
        SortOrder = 3)]
    public class SubmitSearchQuery : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "Search query in Keyword Query Language (KQL).")]
        public string Query = string.Empty;

        [Parameter(Mandatory = false, HelpMessage = "Search result item to start returning the results from. Useful for paging. Leave at 0 to return all results.")]
        public int StartRow = 0;

        [Parameter(Mandatory = false, HelpMessage = "Maximum amount of search results to return. Default and max per page is 500 search results.")]
        [ValidateRange(0, 500)]
        public int MaxResults = 500;

        [Parameter(Mandatory = false, HelpMessage = "Automatically page results until the end. Use with caution!")]
        public bool AutoPaging = false;

        [Parameter(Mandatory = false, HelpMessage = "Specifies whether near duplicate items should be removed from the search results.")]
        public bool TrimDuplicates = false;

        [Parameter(Mandatory = false, HelpMessage = "Extra query properties. Can for example be used for Office Graph queries.")]
        public Hashtable Properties;

        [Parameter(Mandatory = false, HelpMessage = "The list of refiners to be returned in a search result.")]
        public string Refiners;

        [Parameter(Mandatory = false, HelpMessage = "The locale for the query.")]
        public int Culture;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the query template that is used at run time to transform the query based on user input.")]
        public string QueryTemplate;

        [Parameter(Mandatory = false, HelpMessage = "The list of properties to return in the search results.")]
        public string[] SelectProperties;

        [Parameter(Mandatory = false, HelpMessage = "The set of refinement filters used.")]
        public string[] RefinementFilters;

        [Parameter(Mandatory = false, HelpMessage = "The list of properties by which the search results are ordered.")]
        public Hashtable SortList;

        [Parameter(Mandatory = false, HelpMessage = "The identifier (ID) of the ranking model to use for the query.")]
        public string RankingModelId;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the name of the client which issued the query.")]
        public string ClientType = "ContentSearchLow";

        [Parameter(Mandatory = false, HelpMessage = "The keyword query’s hidden constraints.")]
        public string HiddenConstraints;

        [Parameter(Mandatory = false, HelpMessage = "The identifier for the search query time zone.")]
        public int TimeZoneId;

        [Parameter(Mandatory = false, HelpMessage = "Specifies whether the phonetic forms of the query terms are used to find matches.")]
        public bool EnablePhonetic;

        [Parameter(Mandatory = false, HelpMessage = "Specifies whether stemming is enabled.")]
        public bool EnableStemming;

        [Parameter(Mandatory = false, HelpMessage = "Specifies whether Query Rules are enabled for this query.")]
        public bool EnableQueryRules;

        [Parameter(Mandatory = false, HelpMessage = "Specifies the identifier (ID or name) of the result source to be used to run the query.")]
        public Guid SourceId;

        [Parameter(Mandatory = false, HelpMessage = "Determines whether Best Bets are enabled.")]
        public bool ProcessBestBets;

        [Parameter(Mandatory = false, HelpMessage = "Determines whether personal favorites data is processed or not.")]
        public bool ProcessPersonalFavorites;

        protected override void ExecuteCmdlet()
        {
            KeywordQuery keywordQuery = CreateKeywordQuery();
            if (AutoPaging)
            {
                keywordQuery.RowLimit = 500;
                keywordQuery.StartRow = 0;
            }

            var currentCount = 0;
            int start = 0;
            ResultTableCollection finalResults = new ResultTableCollection();
            do
            {
                var searchExec = new SearchExecutor(ClientContext);
                if (start > 0 && AutoPaging)
                {
                    keywordQuery.Refiners = null; // Only need to set on first page for auto paging
                }

                var results = searchExec.ExecuteQuery(keywordQuery);
                ClientContext.ExecuteQueryRetry();

                if (results.Value != null)
                {
                    if (!string.IsNullOrWhiteSpace(keywordQuery.Refiners))
                    {
                        var refinementTable = results.Value.SingleOrDefault(t => t.TableType == "RefinementResults");
                        if(refinementTable != null) finalResults.Add(refinementTable);
                    }

                    var table = results.Value.Single(t => t.TableType == "RelevantResults");
                    
                    currentCount = table.RowCount;
                    start = (start + keywordQuery.RowLimit);
                    foreach (IDictionary<string, object> dictionary in table.ResultRows)
                    {
                        //var path = dictionary["path"] + "";
                        //sites.Add(path);
                    }
                }
            } while (currentCount == keywordQuery.RowLimit && AutoPaging);

            //var dynamicList = new List<dynamic>();
            //if (results?.Value[0].RowCount > 0)
            //{
            //    foreach (var row in results.Value[0].ResultRows)
            //    {
            //        dynamicList.Add(
            //            new
            //            {
            //                Title = row["Title"]?.ToString() ?? "",
            //                Url = row["SPSiteUrl"]?.ToString() ?? "",
            //                Description = row["Description"]?.ToString() ?? "",
            //                WebTemplate = row["WebTemplate"]?.ToString() ?? ""
            //            });
            //    }
            //}

            WriteObject(dynamicList, true);
        }

        private KeywordQuery CreateKeywordQuery()
        {
            var keywordQuery = new KeywordQuery(ClientContext);

            // Construct query to execute
            var query = "";
            if (!string.IsNullOrEmpty(Query))
            {
                query = Query;
            }

            keywordQuery.RowLimit = MaxResults;
            keywordQuery.StartRow = StartRow;
            keywordQuery.QueryText = query;
            keywordQuery.TrimDuplicates = TrimDuplicates;
            keywordQuery.Refiners = Refiners;
            keywordQuery.Culture = Culture;
            keywordQuery.QueryTemplate = QueryTemplate;
            keywordQuery.RankingModelId = RankingModelId;
            keywordQuery.ClientType = ClientType;
            keywordQuery.HiddenConstraints = HiddenConstraints;
            keywordQuery.TimeZoneId = TimeZoneId;
            keywordQuery.EnablePhonetic = EnablePhonetic;
            keywordQuery.EnableStemming = EnableStemming;
            keywordQuery.EnableQueryRules = EnableQueryRules;
            keywordQuery.SourceId = SourceId;
            keywordQuery.ProcessBestBets = ProcessBestBets;
            keywordQuery.ProcessPersonalFavorites = ProcessPersonalFavorites;

            if (SortList != null)
            {
                keywordQuery.SortList.Clear();
                foreach (string key in SortList.Keys)
                {
                    SortDirection sort = (SortDirection)Enum.Parse(typeof(SortDirection), SortList[key] as string, true);
                    keywordQuery.SortList.Add(key, sort);
                }
            }
            if (SelectProperties != null)
            {
                foreach (string property in SelectProperties)
                {
                    keywordQuery.SelectProperties.Add(property);
                }
            }
            if (RefinementFilters != null)
            {
                foreach (string property in RefinementFilters)
                {
                    keywordQuery.RefinementFilters.Add(property);
                }
            }
            if (Properties != null)
            {
                foreach (string key in Properties.Keys)
                {
                    QueryPropertyValue propVal = new QueryPropertyValue();
                    var value = Properties[key];
                    if (value is string)
                    {
                        propVal.StrVal = (string)value;
                        propVal.QueryPropertyValueTypeIndex = 1;
                    }
                    else if (value is int)
                    {
                        propVal.IntVal = (int)value;
                        propVal.QueryPropertyValueTypeIndex = 2;
                    }
                    else if (value is bool)
                    {
                        propVal.BoolVal = (bool)value;
                        propVal.QueryPropertyValueTypeIndex = 3;
                    }
                    else if (value is string[])
                    {
                        propVal.StrArray = (string[])value;
                        propVal.QueryPropertyValueTypeIndex = 4;
                    }
                    keywordQuery.Properties.SetQueryPropertyValue(key, propVal);
                }
            }
            return keywordQuery;
        }
    }
}

