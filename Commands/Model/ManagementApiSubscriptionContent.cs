using Newtonsoft.Json;
using System;

namespace PnP.PowerShell.Commands.Model
{
    class ManagementApiSubscriptionContent
    {
        [JsonProperty("contentUri")]
        public string ContentUri { get; set; }

        [JsonProperty("contentId")]
        public string ContentId { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("contentCreated")]
        public DateTime ContentCreated { get; set; }

        [JsonProperty("contentExpiration")]
        public DateTime ContentExpiration { get; set; }
    }
}
