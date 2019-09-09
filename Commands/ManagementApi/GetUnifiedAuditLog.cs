using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Newtonsoft.Json;
using OfficeDevPnP.Core.Framework.Graph;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Model;

namespace SharePointPnP.PowerShell.Commands.ManagementApi
{

    public enum AuditContentType
    {
        AzureActiveDirectory,
        Exchange,
        SharePoint,
        General,
        DLP
    }

    [Cmdlet(VerbsCommon.Get, "PnPUnifiedAuditLog")]
    [CmdletHelp(
        "Gets unified audit logs from O365 Management API",
        Category = CmdletHelpCategory.ManagementApi,
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPUnifiedAuditLog -ContentType SharePoint  -StartTime ([DateTime]::Today.AddDays(-1)) -EndTime  ([DateTime]::Today.AddDays(-2))",
       Remarks = "Retrieves access token for Management API and uses it in PnP connection",
       SortOrder = 1)]
    public class GetUnifiedAuditLog : PnPGraphCmdlet
    {
        private const string ParameterSet_LogsByDate = "Logs by date";

        [Parameter(Mandatory = false, HelpMessage = "Content type of logs to be retreived, should be one of the following: AzureActiveDirectory, Exchange, SharePoint, General, DLP.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_LogsByDate, HelpMessage = "Content type of logs to be retreived, should be one of the following: AzureActiveDirectory, Exchange, SharePoint, General, DLP.")]
        public AuditContentType ContentType = AuditContentType.SharePoint;

        [Parameter(
            Mandatory = false,
            ParameterSetName = ParameterSet_LogsByDate,
            HelpMessage = "Start time of logs to be retreived. Start time and end time must both be specified (or both omitted) and must be less than or equal to 24 hours apart, with the start time prior to  end time and start time no more than 7 days in the past.")]
        public DateTime StartTime = DateTime.MinValue;

        [Parameter(
            Mandatory = false,
            ParameterSetName = ParameterSet_LogsByDate,
            HelpMessage = "End time of logs to be retreived. Start time and end time must both be specified (or both omitted) and must be less than or equal to 24 hours apart.")]
        public DateTime EndTime = DateTime.MaxValue;

        private string tenantId;
        protected string TenantId
        {
            get
            {
                if (string.IsNullOrEmpty(tenantId) && !string.IsNullOrEmpty(AccessToken))
                {
                    var jwtToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(AccessToken);
                    tenantId = jwtToken.Claims.FirstOrDefault(c => c.Type == "tid").Value;
                }
                return tenantId;
            }
        }

        protected string ContentTypeString
        {
            get
            {
                string res = null;
                switch (ContentType)
                {
                    case AuditContentType.AzureActiveDirectory:
                        res = "Audit.AzureActiveDirectory";
                        break;
                    case AuditContentType.SharePoint:
                        res = "Audit.SharePoint";
                        break;
                    case AuditContentType.Exchange:
                        res = "Audit.Exchange";
                        break;
                    case AuditContentType.DLP:
                        res = "DLP.All";
                        break;
                    case AuditContentType.General:
                    default:
                        res = "Audit.General";
                        break;
                }
                return res;
            }
        }

        protected string RootUrl
        {
            get
            {
                return $"https://manage.office.com/api/v1.0/{TenantId}/activity/feed/";
            }
        }

        private IEnumerable<ManagementApiSubscription> GetSubscriptions()
        {
            var url = $"{RootUrl}/subscriptions/list";
            var res = GraphHttpClient.MakeGetRequestForString(url.ToString(), AccessToken);
            var subscriptions = JsonConvert.DeserializeObject<IEnumerable<ManagementApiSubscription>>(res);
            return subscriptions;
        }

        private void EnsureSubscription(string contentType)
        {
            var subscriptions = GetSubscriptions();
            var subscription = subscriptions.FirstOrDefault(s => s.ContentType == contentType);
            if (subscription == null)
            {
                var url = $"{RootUrl}/subscriptions/start?contentType={contentType}&PublisherIdentifier={TenantId}";
                var res = GraphHttpClient.MakePostRequestForString(url.ToString(), accessToken: AccessToken);
                var response = JsonConvert.DeserializeObject<ManagementApiSubscription>(res);
                if (response.Status != "enabled")
                {
                    throw new Exception($"Cannot enable subscription for {contentType}");
                }
            }
        }

        protected override void ExecuteCmdlet()
        {
            EnsureSubscription(ContentTypeString);

            var url = $"{RootUrl}/subscriptions/content?contentType={ContentTypeString}&PublisherIdentifier=${tenantId}";
            if (StartTime != DateTime.MinValue)
            {
                url += $"&startTime={StartTime.ToString("yyyy-MM-ddThh:mm:ss")}";
            }
            if (EndTime != DateTime.MaxValue)
            {
                url += $"&endTime={EndTime.ToString("yyyy-MM-ddThh:mm:ss")}";
            }
            var res = GraphHttpClient.MakeGetRequestForString(url.ToString(), AccessToken);
            if (!string.IsNullOrEmpty(res))
            {
                var contents = JsonConvert.DeserializeObject<IEnumerable<ManagementApiSubscriptionContent>>(res);
                foreach (var content in contents)
                {
                    res = GraphHttpClient.MakeGetRequestForString(content.ContentUri, AccessToken);
                    var logs = JsonConvert.DeserializeObject<IEnumerable<ManagementApiUnifiedLogRecord>>(res);
                    WriteObject(logs, true);
                }
            }
        }
    }
}
