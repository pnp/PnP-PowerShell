using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Linq;
using System.Diagnostics;
using System.Management.Automation;
using System.Net;
using System.Collections.Generic;
using System.Threading;

namespace SharePointPnP.PowerShell.Commands.Diagnostic
{
    [Cmdlet(VerbsDiagnostic.Measure, "PnPResponseTime")]
    [CmdletHelp("Returns the current site collection from the context.",
    Category = CmdletHelpCategory.Diagnostic)]
    public class MeasureResponseTime : PnPCmdlet
    {
        private ProgressRecord progressRecord = new ProgressRecord(0, "Measuring response time", "Sending probe requests");

        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0)]
        public EndpointPipeBind Endpoint;

        [Parameter(Mandatory = false)]
        public int Count = 20;

        [Parameter(Mandatory = false)]
        public int Timeout = 500;

        protected override void ExecuteCmdlet()
        {
            var uri = GetEndpointUri();
            Stopwatch timer = new Stopwatch();
            List<long> times = new List<long>();

            for (int i = 0; i < Count; i++)
            {
                HttpWebRequest probe = HttpWebRequest.CreateHttp(uri);
                probe.AllowAutoRedirect = false;
                ClientRuntimeContext.SetupRequestCredential(ClientContext, probe);
                WriteProgress($"Sending probe request to {uri}", i);
                timer.Restart();
                var response = probe.GetResponse() as HttpWebResponse;
                timer.Stop();
                times.Add(timer.ElapsedMilliseconds);

                if(response.StatusCode != HttpStatusCode.OK)
                {
                    if(response.StatusCode < HttpStatusCode.BadRequest)
                    {
                        WriteWarning($"Unexpected status code received {(int)response.StatusCode}");
                    }
                    else
                    {
                        WriteError(new ErrorRecord(new Exception($"Probe request failed with status code {(int)response.StatusCode}"), "1", ErrorCategory.NotSpecified, null));
                    }
                }
                WriteVerbose($"Reponse received in {timer.ElapsedMilliseconds}ms");
                WriteProgress($"Sleeping", i);
                Thread.Sleep(Timeout);
            }

            progressRecord.RecordType = ProgressRecordType.Completed;
            WriteProgress(progressRecord);

            WriteObject(new {
                Average = times.Average(),
                Max = times.Max(),
                Min = times.Min(),
                StandardDeviation = GetStandardDeviation(times)
            });
        }

        private void WriteProgress(string message, int step)
        {
            var percentage = Convert.ToInt32((100 / Convert.ToDouble(Count)) * Convert.ToDouble(step));
            progressRecord.StatusDescription = message;
            progressRecord.PercentComplete = percentage;
            progressRecord.RecordType = ProgressRecordType.Processing;
            WriteProgress(progressRecord);
        }

        private long GetStandardDeviation(IEnumerable<long> array)
        {
            double average = array.Average();
            double sumOfSquaresOfDifferences = array.Select(val => (val - average) * (val - average)).Sum();
            return (long)Math.Sqrt(sumOfSquaresOfDifferences / array.Count());
        }

        private Uri GetEndpointUri()
        {
            if(Endpoint == null)
            {
                Endpoint = new EndpointPipeBind(ClientContext.Web);
            }
            var res = new Uri(Endpoint.ToString(), UriKind.Relative);
            var serverAuthority = new Uri(ClientContext.Url).GetLeftPart(UriPartial.Authority);
            res = new Uri(serverAuthority + res.ToString(), UriKind.Absolute);

            return res;
        }
    }

    public sealed class EndpointPipeBind
    {
        private string _serverRelativeUrl;
        private Web _web;
        private File _file;
        private Folder _folder;

        public EndpointPipeBind()
        {
            _serverRelativeUrl = null;
            _web = null;
            _file = null;
            _folder = null;
        }

        public EndpointPipeBind(string serverRelativeUrl)
        {
            _serverRelativeUrl = serverRelativeUrl;
        }

        public EndpointPipeBind(Web web)
        {
            _web = web;
        }

        public EndpointPipeBind(File file)
        {
            _file = file;
        }

        public EndpointPipeBind(Folder folder)
        {
            _folder = folder;
        }

        public override string ToString()
        {
            if (_serverRelativeUrl == null)
            {
                if (_web != null)
                {
                    _web.EnsureProperty(w => w.RootFolder);
                    _folder =_web.RootFolder;
                }
                if (_folder != null)
                {
                    _folder.EnsureProperties(f => f.WelcomePage, f => f.ServerRelativeUrl);
                    _serverRelativeUrl = System.IO.Path.Combine(_folder.ServerRelativeUrl, _folder.WelcomePage);
                }
                if (_file != null)
                {
                    _file.EnsureProperty(f => f.ServerRelativeUrl);
                    _serverRelativeUrl = _file.ServerRelativeUrl;
                }
            }
            return _serverRelativeUrl;
        }
    }
}
