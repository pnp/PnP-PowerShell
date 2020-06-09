using Newtonsoft.Json;
using System.Collections.Generic;

namespace SharePointPnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Information regarding one Office 365 service
    /// </summary>
    public class ManagementApiService
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Features")]
        public IEnumerable<ManagementApiFeature> Features { get; set; }
    }
}
