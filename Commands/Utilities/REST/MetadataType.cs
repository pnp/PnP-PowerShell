using Newtonsoft.Json;

namespace PnP.PowerShell.Commands.Utilities.REST
{
    public class MetadataType
    {
        [JsonProperty("type")]
        public string _typename;

        public MetadataType(string typename)
        {
            this._typename = typename;
        }
    }
}