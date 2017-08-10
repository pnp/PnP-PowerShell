using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Diagnostic
{
    public sealed class ResponseTimeStatistics
    {
        public double Average { get; set; }
        public long Max { get; set; }
        public long Min { get; set; }
        public double StandardDeviation { get; set; }
        public double TruncatedAverage { get; set; }
        public long Count { get; set; }
    }
}
