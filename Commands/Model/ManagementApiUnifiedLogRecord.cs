using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Model
{
    class ManagementApiUnifiedLogRecord
    {
        public DateTime CreationTime { get; set; }
        public Guid Id { get; set; }
        public string Operation { get; set; }
        public Guid OrganizationId { get; set; }
        public int RecordType { get; set; }
        public string UserKey { get; set; }
        public int UserType { get; set; }
        public int Version { get; set; }
        public string Workload { get; set; }
        public string ClientIP { get; set; }
        public string ObjectId { get; set; }
        public string UserId { get; set; }
        public Guid CorrelationId { get; set; }
        public string EventSource { get; set; }
        public string ItemType { get; set; }
        public string UserAgent { get; set; }
        public string EventData { get; set; }
    }
}
