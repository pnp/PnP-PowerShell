using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.PowerShell.Commands.InvokeAction
{
    internal class InvokeActionResult
    {
        public int TotalWebCount { get; set; }
        public int TotalListCount { get; set; }
        public int TotalListItemCount { get; set; }

        public double AverageWebTime { get; set; }
        public double AverageListTime { get; set; }
        public double AverageListItemTime { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan TotalExecutionTime { get; set; }
    }
}
