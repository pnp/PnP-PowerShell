using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharePointPnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Information regarding a message concerning a service in Office 365
    /// </summary>
    public class ManagementApiServiceMessage
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("ActionType")]
        public string ActionType { get; set; }

        [JsonProperty("ActionDetails")]
        public string ActionDetails { get; set; }

        [JsonProperty("AffectedTenantCount")]
        public int? AffectedTenantCount { get; set; }

        [JsonProperty("AffectedUserCount")]
        public int? AffectedUserCount { get; set; }

        [JsonProperty("AffectedWorkloadDisplayNames")]
        public IEnumerable<string> AffectedWorkloadDisplayNames { get; set; }

        [JsonProperty("AffectedWorkloadNames")]
        public IEnumerable<string> AffectedWorkloadNames { get; set; }

        [JsonProperty("AnnouncementId")]
        public string AnnouncementId { get; set; }

        [JsonProperty("AppliesTo")]
        public string AppliesTo { get; set; }

        [JsonProperty("BlogLink")]
        public string BlogLink { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Classification")]
        public string Classification { get; set; }

        [JsonProperty("EndTime")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("ExternalLink")]
        public string ExternalLink { get; set; }

        [JsonProperty("FeatureDisplayName")]
        public string FeatureDisplayName { get; set; }

        [JsonProperty("Feature")]
        public string Feature { get; set; }

        [JsonProperty("FlightName")]
        public string FlightName { get; set; }

        [JsonProperty("HelpLink")]
        public string HelpLink { get; set; }

        [JsonProperty("ImpactDescription")]
        public string ImpactDescription { get; set; }

        [JsonProperty("IsDismissed")]
        public bool? IsDismissed { get; set; }

        [JsonProperty("IsMajorChange")]
        public bool? IsMajorChange { get; set; }

        [JsonProperty("IsRead")]
        public bool? IsRead { get; set; }

        [JsonProperty("LastUpdatedTime")]
        public DateTime? LastUpdatedTime { get; set; }
        
        [JsonProperty("Messages")]
        public IEnumerable<ManagementApiServiceMessageText> Messages { get; set; }

        [JsonProperty("MessageTagNames")]
        public IEnumerable<string> MessageTagNames { get; set; }

        [JsonProperty("MessageType")]
        public string MessageType { get; set; }

        [JsonProperty("Milestone")]
        public string Milestone { get; set; }

        [JsonProperty("MilestoneDate")]
        public DateTime? MilestoneDate { get; set; }

        [JsonProperty("PostIncidentDocumentUrl")]
        public string PostIncidentDocumentUrl { get; set; }

        [JsonProperty("PreviewDuration")]
        public string PreviewDuration { get; set; }

        [JsonProperty("Severity")]
        public string Severity { get; set; }

        [JsonProperty("StartTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("UserFunctionalImpact")]
        public string UserFunctionalImpact { get; set; }

        [JsonProperty("Workload")]
        public string Workload { get; set; }

        [JsonProperty("WorkloadDisplayName")]
        public string WorkloadDisplayName { get; set; }
    }
}
