using Newtonsoft.Json;

namespace PnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Information regarding one Office 365 service feature
    /// </summary>
    public class ManagementApiFeature
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }
    }
}
