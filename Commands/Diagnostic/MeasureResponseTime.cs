using System;
using System.Net;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Diagnostic
{
    [Cmdlet(VerbsDiagnostic.Measure, "PnPResponseTime")]
    [CmdletHelp("Measures response time for the specified endpoint by sending probe requests and gathering stats.",
        Category = CmdletHelpCategory.Diagnostic)]
    public class MeasureResponseTime : PnPCmdlet
    {
        private ProgressRecord _progressRecord = new ProgressRecord(0, "Measuring response time", "Sending probe requests");

        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0)]
        public DiagnosticEndpointPipeBind Url;

        [Parameter(Mandatory = false, HelpMessage = "Number of probe requests")]
        public uint Count = 20;

        [Parameter(Mandatory = false, HelpMessage = "Number of warm up requests")]
        public uint WarmUp = 1;

        [Parameter(Mandatory = false, HelpMessage = "Idle timeout between requests")]
        public uint Timeout = 500;

        [Parameter(Mandatory = false, HelpMessage = "Number of buckets in histogram")]
        public uint Histogram = 5;

        protected override void ExecuteCmdlet()
        {
            var uri = GetEndpointUri();
            Stopwatch timer = new Stopwatch();
            List<long> measurements = new List<long>();
            try
            {
                for (int i = -(int)WarmUp; i < Count; i++)
                {
                    bool isWarmUp = i < 0;
                    var probe = WebRequest.CreateHttp(uri);
                    probe.AllowAutoRedirect = false;

                    ClientRuntimeContext.SetupRequestCredential(ClientContext, probe);
                    WriteProgress(isWarmUp ? $"Warming up: {WarmUp + i + 1}/{WarmUp}": $"Sending: {uri}", i);

                    HttpWebResponse response = null;
                    try
                    {
                        try
                        {
                            timer.Restart();
                            response = probe.GetResponse() as HttpWebResponse;
                            timer.Stop();
                        }
                        catch (WebException e)
                        {
                            timer.Stop();
                            response = e.Response as HttpWebResponse;
                            if (response == null)
                            {
                                throw;
                            }
                        }
                        if (!isWarmUp)
                        {
                            measurements.Add(timer.ElapsedMilliseconds);
                        }

                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            WriteWarning($"Reply from {uri}: {(int)response.StatusCode}");
                        }
                    }
                    finally
                    {
                        if(response != null)
                        {
                            response.Dispose();
                        }
                    }
                    if (!isWarmUp)
                    {
                        WriteVerbose($"Reply from {uri}: {timer.ElapsedMilliseconds}ms");
                    }
                    WriteProgress($"Sleeping: {Timeout}ms", i);
                    Thread.Sleep((int)Timeout);
                }
                _progressRecord.RecordType = ProgressRecordType.Completed;
                WriteProgress(_progressRecord);

            }
            finally
            {
                WriteObject(GetStatistics(measurements));
            }
        }

        private void WriteProgress(string message, int step)
        {
            var total = Count + WarmUp;
            var percentage = total != 0 ? Convert.ToInt32((100 / Convert.ToDouble(total)) * Convert.ToDouble(step)) : 100;
            _progressRecord.StatusDescription = message;
            _progressRecord.PercentComplete = percentage;
            _progressRecord.RecordType = ProgressRecordType.Processing;
            WriteProgress(_progressRecord);
        }

        private ResponseTimeStatistics GetStatistics(IEnumerable<long> array)
        {
            double average = 0;
            long max = 0;
            long min = 0;
            int count = 0;
            double truncatedAverage = 0;
            double standardDeviation = 0;
            Dictionary<long, int> histogram = new Dictionary<long, int>();

            if (array != null && array.Count() > 0)
            {
                count = array.Count();
                array = array.OrderBy(a => a);
                min = array.First();
                max = array.Last();
                average = array.Average();
                double sumOfSquaresOfDifferences = array.Select(val => (val - average) * (val - average)).Sum();
                standardDeviation = Math.Sqrt(sumOfSquaresOfDifferences / count);

                if (count > 10)
                {
                    var trunc = (int)Math.Round(count * 0.1);
                    truncatedAverage = array.Skip(trunc).Take(count - 2 * trunc).Average();
                }

                if(Histogram > 0)
                {
                    //build histogram
                    var bucketSize = max/(double)Histogram;
                    for (int i = 0; i < Histogram; i++)
                    {
                        var bucketMin = bucketSize * i;
                        var bucketMax = bucketSize * (i + 1);
                        histogram[(long)bucketMax] = array.Where(a => 
                        a >= bucketMin && (a <= bucketMax || (i == Histogram - 1))).Count();
                    }
                }
            }
            return new ResponseTimeStatistics
            {
                Average = Math.Round(average, 2),
                Max = max,
                Min = min,
                StandardDeviation = Math.Round(standardDeviation, 2),
                TruncatedAverage = truncatedAverage,
                Count = count,
                Histogram = Histogram > 0 ? histogram : null
            };
        }

        private Uri GetEndpointUri()
        {
            if (Url == null)
            {
                Url = new DiagnosticEndpointPipeBind(ClientContext.Web);
            }
            var uri = new Uri(Url.ToString(), UriKind.Relative);
            var authority = new Uri(ClientContext.Url).GetLeftPart(UriPartial.Authority);
            uri = new Uri(authority + uri.ToString(), UriKind.Absolute);
            return uri;
        }
    }
}
