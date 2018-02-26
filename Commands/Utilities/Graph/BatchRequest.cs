using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Utilities.Graph
{
    public class Batch
    {
        [JsonProperty("requests")]
        public List<BatchRequest> Requests { get; set; }

        public Batch()
        {
            this.Requests = new List<BatchRequest>();
        }

        public void Add(BatchRequest request)
        {
            if (request.Id == 0)
            {
                int id = 1;
                if (this.Requests.Any())
                {
                    id = this.Requests.Max(r => r.Id) + 1;
                }
                request.Id = id;
            }
            Requests.Add(request);
        }

        public void Add(string method, string url)
        {
            var request = new BatchRequest();
            if (request.Id == 0)
            {
                int id = 1;
                if (this.Requests.Any())
                {
                    id = this.Requests.Max(r => r.Id) + 1;
                }
                request.Id = id;
            }
            request.Method = method;
            request.Url = url;
            Requests.Add(request);
        }

        public void Add(int id, string method, string url, int? dependsOn = null)
        {
            var request = new BatchRequest();
            request.Id = id;
            request.Method = method;
            request.Url = url;
            if (dependsOn.HasValue)
            {
                request.DependsOn = dependsOn.Value;
            }
            Requests.Add(request);

        }
    }

    public class BatchRequest
    {
        [JsonProperty("id")]
        public string StringId
        {
            get
            {
                return Id.ToString();
            }
        }

        [JsonProperty("dependsOn")]
        public string[] DependsOnString
        {
            get
            {
                return new List<string>() { DependsOn.ToString() }.ToArray();
            }
        }

        [JsonIgnore]
        public int DependsOn { get; set; } = -1;

        [JsonIgnore]
        public int Id { get; set; } = 0;

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public bool ShouldSerializeDependsOnString()
        {
            return DependsOn != -1;
        }
    }
}
