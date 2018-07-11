using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Administration;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Search
{
    public enum LogLevel
    {
        All = -1,
        Success = 0,
        Warning = 1,
        Error = 2
    }

    public enum ContentSource
    {
        Sites,
        UserProfiles
    }

    public class CrawlEntry
    {
        public string Url { get; set; }
        public DateTime CrawlTime { get; set; }
        public DateTime ItemTime { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Status { get; set; }
        public int ItemId { get; set; }
        public int ContentSourceId { get; set; }
    }

    [Cmdlet(VerbsCommon.Get, "PnPSearchCrawlLog", DefaultParameterSetName = "Xml")]
    [CmdletHelp("Returns entries from the SharePoint search crawl log",
        SupportedPlatform = CmdletSupportedPlatform.Online,
        Category = CmdletHelpCategory.Search)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchCrawlLog",
        Remarks = "Returns the last 100 crawl log entries for site content.",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchCrawlLog -Filter ""https://<tenant>-my.sharepoint.com/personal""",
        Remarks = "Returns the last 100 crawl log entries for OneDrive content.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchCrawlLog -ContentSource UserProfiles ",
        Remarks = "Returns the last 100 crawl log entries for user profiles.",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchCrawlLog -ContentSource UserProfiles -Filter ""mikael""",
        Remarks = @"Returns the last 100 crawl log entries for user profiles with the term ""mikael"" in the user principal name.",
        SortOrder = 4)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchCrawlLog -ContentSource Sites LogLevel Error -RowLimit 10",
        Remarks = @"Returns the last 10 crawl log entries with a state of Error for site content.",
        SortOrder = 5)]
    [CmdletExample(
        Code = @"PS:> Get-PnPSearchCrawlLog -EndDate (Get-Date).AddDays(-100)",
        Remarks = @"Returns the last 100 crawl log entries for site content up until 100 days ago.",
        SortOrder = 6)]
    public class GetSearchCrawlLog : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Filter what log entries to return (All, Success, Warning, Error). Defaults to All")]
        public LogLevel LogLevel = LogLevel.All;

        [Parameter(Mandatory = false, HelpMessage = "Number of entries to return. Defaults to 100.")]
        public int RowLimit = 100;

        [Parameter(Mandatory = false, HelpMessage = "Filter to limit what is being returned. Has to be a URL prefix for SharePoint content, and part of a user principal name for user profiles. Wildcard characters are not supported.")]
        public string Filter;

        [Parameter(Mandatory = false, HelpMessage = "Content to retrieve (Sites, User Profiles). Defaults to Sites.")]
        public ContentSource ContentSource = ContentSource.Sites;

        [Parameter(Mandatory = false, HelpMessage = "Start date to start getting entries from. Defaults to start of time.")]
        public DateTime StartDate = DateTime.MinValue;

        [Parameter(Mandatory = false, HelpMessage = "End date to stop getting entries from. Default to current time.")]
        public DateTime EndDate = DateTime.UtcNow.AddDays(1);

        private const int MaxRows = 100000;

        protected override void ExecuteCmdlet()
        {
            try
            {
                var crawlLog = new DocumentCrawlLog(ClientContext, ClientContext.Site);
                ClientContext.Load(crawlLog);

                int contentSourceId;
                switch (ContentSource)
                {
                    case ContentSource.Sites:
                        contentSourceId = GetContentSourceIdForSites(crawlLog);
                        break;
                    case ContentSource.UserProfiles:
                        contentSourceId = GetContentSourceIdForUserProfiles(crawlLog);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                string postFilter = string.Empty;
                if (string.IsNullOrWhiteSpace(Filter) && ContentSource == ContentSource.Sites)
                {
                    Filter = $"https://{GetHostName()}.sharepoint.com";
                }

                int origLimit = RowLimit;
                if (ContentSource == ContentSource.UserProfiles)
                {
                    postFilter = Filter;
                    Filter = $"https://{GetHostName()}-my.sharepoint.com";
                    RowLimit = MaxRows;
                }

                var logEntries = crawlLog.GetCrawledUrls(false, RowLimit, Filter, true, contentSourceId, (int)LogLevel, -1, StartDate, EndDate);
                ClientContext.ExecuteQueryRetry();
                var entries = new List<CrawlEntry>(logEntries.Value.Rows.Count);
                foreach (var dictionary in logEntries.Value.Rows)
                {
                    var entry = MapCrawlLogEntry(dictionary);
                    if (string.IsNullOrWhiteSpace(postFilter))
                    {
                        entries.Add(entry);
                    }
                    else if (entry.Url.Contains(postFilter))
                    {
                        entries.Add(entry);
                    }

                }
                WriteObject(entries.Take(origLimit).OrderByDescending(i => i.CrawlTime).ToList());
            }
            catch (Exception e)
            {
                WriteError(new ErrorRecord(new Exception("Make sure you are granted access to the crawl log via the SharePoint search admin center at https://<tenant>-admin.sharepoint.com/_layouts/15/searchadmin/TA_searchadministration.aspx"), e.Message, ErrorCategory.AuthenticationError, null));
            }
        }

        #region Helper functions

        private string GetHostName()
        {
            return new Uri(ClientContext.Url).Host.Replace("-admin", "").Replace("-public", "").Replace("-my", "").Replace(".sharepoint.com", "");
        }

        private int GetContentSourceIdForSites(DocumentCrawlLog crawlLog)
        {
            var hostName = GetHostName();
            var spContent = crawlLog.GetCrawledUrls(false, 10, $"https://{hostName}.sharepoint.com/sites", true, -1, (int)LogLevel.All, -1, DateTime.Now.AddDays(-100), DateTime.Now.AddDays(1));
            ClientContext.ExecuteQueryRetry();
            return (int)spContent.Value.Rows.First()["ContentSourceID"];
        }

        private int GetContentSourceIdForUserProfiles(DocumentCrawlLog crawlLog)
        {
            var hostName = GetHostName();
            var peopleContent = crawlLog.GetCrawledUrls(false, 100, $"sps3s://{hostName}-my.sharepoint.com", true, -1, (int)LogLevel.All, -1, DateTime.Now.AddDays(-100), DateTime.Now.AddDays(1));
            ClientContext.ExecuteQueryRetry();
            return (int)peopleContent.Value.Rows.First()["ContentSourceID"];
        }

        private static CrawlEntry MapCrawlLogEntry(Dictionary<string, object> dictionary)
        {
            var entry = new CrawlEntry
            {
                ItemId = (int)dictionary["URLID"],
                ContentSourceId = (int)dictionary["ContentSourceID"],
                Url = dictionary["FullUrl"].ToString(),
                CrawlTime = (DateTime)dictionary["TimeStampUtc"]
            };
            long.TryParse(dictionary["LastRepositoryModifiedTime"] + "", out long ticks);
            if (ticks != 0)
            {
                var itemDate = DateTime.FromFileTimeUtc(ticks);
                entry.ItemTime = itemDate;
            }
            entry.LogLevel =
                (LogLevel)Enum.Parse(typeof(LogLevel), dictionary["ErrorLevel"].ToString());

            entry.Status = dictionary["StatusMessage"] + "";
            return entry;
        }
        #endregion
    }
}
