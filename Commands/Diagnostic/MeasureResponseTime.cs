using System;
using System.Linq;
using System.Diagnostics;
using System.Management.Automation;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Diagnostic
{
    [Cmdlet(VerbsDiagnostic.Measure, "PnPResponseTime")]
    [CmdletHelp("Returns the current site collection from the context.",
    Category = CmdletHelpCategory.Diagnostic)]
    public class MeasureResponseTime : PnPCmdlet
    {
        private ProgressRecord progressRecord = new ProgressRecord(0, "Measuring response time", "Sending probe requests");

        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0)]
        public DiagnosticEndpointPipeBind Endpoint;

        [Parameter(Mandatory = false)]
        public int Count = 20;

        [Parameter(Mandatory = false)]
        public int Timeout = 500;

        protected override void ExecuteCmdlet()
        {
            var uri = GetEndpointUri();
            Stopwatch timer = new Stopwatch();
            List<long> measurements = new List<long>();
            int i = 0;
            try
            {
                for (i = 0; i < Count; i++)
                {
                    HttpWebRequest probe = HttpWebRequest.CreateHttp(uri);
                    probe.AllowAutoRedirect = false;

                    ClientRuntimeContext.SetupRequestCredential(ClientContext, probe);
                    WriteProgress($"Sending probe request to {uri}", i);

                    HttpWebResponse response = null;
                    try
                    {
                        timer.Restart();
                        response = probe.GetResponse() as HttpWebResponse;
                        timer.Stop();
                    }
                    catch(WebException e)
                    {
                        timer.Stop();
                        response = e.Response as HttpWebResponse;
                        if(response == null)
                        {
                            throw;
                        }
                    }

                    measurements.Add(timer.ElapsedMilliseconds);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        if (response.StatusCode < HttpStatusCode.BadRequest)
                        {
                            WriteWarning($"Unexpected status code received {(int)response.StatusCode}");
                        }
                        else
                        {
                            WriteWarning($"Probe request failed with status code {(int)response.StatusCode}");
                        }
                    }
                    WriteVerbose($"Reponse received in {timer.ElapsedMilliseconds}ms");
                    WriteProgress($"Sleeping", i);
                    Thread.Sleep(Timeout);
                }
                progressRecord.RecordType = ProgressRecordType.Completed;
                WriteProgress(progressRecord);

            }
            finally
            {
                WriteObject(GetStatistics(measurements));
            }
        }

        private void WriteProgress(string message, int step)
        {
            var percentage = Convert.ToInt32((100 / Convert.ToDouble(Count)) * Convert.ToDouble(step));
            progressRecord.StatusDescription = message;
            progressRecord.PercentComplete = percentage;
            progressRecord.RecordType = ProgressRecordType.Processing;
            WriteProgress(progressRecord);
        }

        private ResponseTimeStatistics GetStatistics(IEnumerable<long> array)
        {
            double average = 0;
            long max = 0;
            long min = 0;
            int count = 0;
            double truncatedAverage = 0;
            double standardDeviation = 0;

            if (array != null && array.Count() > 0)
            {
                count = array.Count();
                array = array.OrderBy(a => a);
                min = array.First();
                max = array.Last();
                average = array.Average();
                double sumOfSquaresOfDifferences = array.Select(val => (val - average)* (val - average)).Sum();
                standardDeviation =  Math.Sqrt(sumOfSquaresOfDifferences / count);

                if (count > 10)
                {
                    var trunc = (int)Math.Round(count * 0.1);
                    truncatedAverage = array.Skip(trunc).Take(count - 2 * trunc).Average();
                }
            }
            return new ResponseTimeStatistics()
            {
                Average = Math.Round(average, 2),
                Max = max,
                Min = min,
                StandardDeviation = Math.Round(standardDeviation, 2),
                TruncatedAverage = truncatedAverage,
                Count = count
            };
        }

        private Uri GetEndpointUri()
        {
            if(Endpoint == null)
            {
                Endpoint = new DiagnosticEndpointPipeBind(ClientContext.Web);
            }
            var res = new Uri(Endpoint.ToString(), UriKind.Relative);
            var serverAuthority = new Uri(ClientContext.Url).GetLeftPart(UriPartial.Authority);
            res = new Uri(serverAuthority + res.ToString(), UriKind.Absolute);

            return res;
        }
    }
}
