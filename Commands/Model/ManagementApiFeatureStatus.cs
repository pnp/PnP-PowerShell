using Newtonsoft.Json;

namespace SharePointPnP.PowerShell.Commands.Model
{
    /// <summary>
    /// Information regarding the current status of a specific feature in an Office 365 service
    /// </summary>
    public class ManagementApiFeatureStatus
    {
        [JsonProperty("FeatureDisplayName")]
        public string FeatureDisplayName { get; set; }

        [JsonProperty("FeatureName")]
        public string FeatureName { get; set; }

        [JsonProperty("FeatureServiceStatusDisplayName")]
        public string FeatureServiceStatusDisplayName { get; set; }

        [JsonProperty("FeatureServiceStatus")]
        public string FeatureServiceStatus { get; set; }
    }
}
