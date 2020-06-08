using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SharePointPnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Information regarding the current status of an Office 365 service
    /// </summary>
    public class ManagementApiServiceStatus
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("StatusDisplayName")]
        public string StatusDisplayName { get; set; }

        [JsonProperty("StatusTime")]
        public DateTime? StatusTime { get; set; }

        [JsonProperty("Workload")]
        public string Workload { get; set; }

        [JsonProperty("WorkloadDisplayName")]
        public string WorkloadDisplayName { get; set; }

        [JsonProperty("IncidentIds")]
        public IEnumerable<string> IncidentIds { get; set; }

        [JsonProperty("FeatureStatus")]
        public IEnumerable<ManagementApiFeatureStatus> FeatureStatus { get; set; }
    }
}
