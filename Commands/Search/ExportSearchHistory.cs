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
    [Cmdlet(VerbsData.Export, "PnPSearchHistory")]
    [CmdletHelp("Executes an arbitrary search query against the SharePoint search index",
        Category = CmdletHelpCategory.Search)]
    [CmdletExample(
        Code = @"PS:> Submit-PnPSearchQuery -Query ""finance""",
        Remarks = "Returns the top 500 items with the term finance",
        SortOrder = 1)]

    public class ExportSearchHistory : PnPWebCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0, HelpMessage = "Search query in Keyword Query Language (KQL).", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public string UserName = "'0#.f|membership|miksvenson@techmikael.com";

        protected override void ExecuteCmdlet()
        {
            KeywordQuery keywordQuery = new KeywordQuery(ClientContext);
            var result = keywordQuery.ExportQueryLogs(UserName, DateTime.Now.AddYears(-2));
            ClientContext.ExecuteQueryRetry();
            WriteObject(result);

        }
    }
}

