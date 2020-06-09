using Newtonsoft.Json;
using System;

namespace SharePointPnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Information regarding the text inside a message concerning a service in Office 365
    /// </summary>
    public class ManagementApiServiceMessageText
    {
        [JsonProperty("MessageText")]
        public string MessageText { get; set; }

        [JsonProperty("PublishedTime")]
        public DateTime? PublishedTime { get; set; }
    }
}
