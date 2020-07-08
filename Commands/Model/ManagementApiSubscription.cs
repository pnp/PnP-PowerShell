using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PnP.PowerShell.Commands.Model
{
    class ManagementApiSubscription
    {
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("webhook")]
        public JObject Webhook { get; set; }
    }
}
