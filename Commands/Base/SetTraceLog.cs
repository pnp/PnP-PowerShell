using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsCommon.Set, "SPOTraceLog")]
    [CmdletHelp("Defines if tracing should be turned on. PnP Core, which is the foundation of these cmdlets utilizes the standard Trace functionality of .NET. With this cmdlet you can turn capturing of this trace to a log file on or off.", Category = "Base Cmdlets")]
    [CmdletExample(
        Code = @"PS:> Set-SPOTraceLog -On -LogFile traceoutput.txt",
        Remarks = @"This turns on trace logging to the file 'traceoutput.txt' and will capture events of at least 'Information' level.",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-SPOTraceLog -On -LogFile traceoutput.txt -Level All",
        Remarks = @"This turns on trace logging to the file 'traceoutput.txt' and will capture all events.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Set-SPOTraceLog -On -LogFile traceoutput.txt -Level All -Delimiter "",""",
        Remarks = @"This turns on trace logging to the file 'traceoutput.txt' and will write the entries as comma separated. All events are captured.",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Set-SPOTraceLog -Off",
        Remarks = @"This turns off trace logging. It will flush any remaining messages to the log file.",
        SortOrder = 3)]
    public class SetTraceLog : PSCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "On", HelpMessage = "Turn on tracing to log file")]
        public SwitchParameter On;

        [Parameter(Mandatory = true, ParameterSetName = "On", HelpMessage = "The path and filename of the file to write the trace log to")]
        public string LogFile;

        [Parameter(Mandatory = false, ParameterSetName = "On", HelpMessage = "The level of events to capture. Possible values are 'ActivityTracing', 'All', 'Critical', 'Error', 'Information', 'Off', 'Verbose', 'Warning'. Defaults to 'Information'.")]
        public SourceLevels Level = SourceLevels.Information;

        [Parameter(Mandatory = false, ParameterSetName = "On", HelpMessage = "If specified the trace log entries will be delimited with this value")]
        public string Delimiter;

        [Parameter(Mandatory = false, ParameterSetName = "On", HelpMessage = "Indents in the tracelog will be with this amount of characters. Defaults to 4.")]
        public int IndentSize = 4;

        [Parameter(Mandatory = false, ParameterSetName = "On", HelpMessage = "Auto flush the trace log. Defaults to true.")]
        public bool AutoFlush = true;

        [Parameter(Mandatory = true, ParameterSetName = "Off", HelpMessage = "Turn off tracing to log file")]
        public SwitchParameter Off;

        private const string LISTENERNAME = "PNPPOWERSHELLTRACELISTENER";
        protected override void ProcessRecord()
        {

            if (ParameterSetName == "On")
            {
                if (!System.IO.Path.IsPathRooted(LogFile))
                {
                    LogFile = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, LogFile);
                }

                var existingListener = Trace.Listeners[LISTENERNAME];
                if (existingListener != null)
                {
                    existingListener.Flush();
                    existingListener.Close();
                    Trace.Listeners.Remove(existingListener);
                }

                if (!string.IsNullOrEmpty(Delimiter))
                {
                    DelimitedListTraceListener delimitedListener = new DelimitedListTraceListener(LogFile);
                    delimitedListener.Delimiter = Delimiter;
                    delimitedListener.TraceOutputOptions = TraceOptions.DateTime;
                    delimitedListener.Filter = new EventTypeFilter(Level);
                    delimitedListener.Name = LISTENERNAME;
                    Trace.Listeners.Add(delimitedListener);
                }
                else
                {
                    TextWriterTraceListener listener = new TextWriterTraceListener(LogFile);
                    listener.Filter = new EventTypeFilter(Level);
                    listener.Name = LISTENERNAME;
                    Trace.Listeners.Add(listener);
                }
                Trace.AutoFlush = AutoFlush;
                Trace.IndentSize = IndentSize;
            }
            else
            {
                Trace.Flush();
                Trace.Listeners[LISTENERNAME].Close();
                Trace.Listeners.Remove(LISTENERNAME);
            }
        }
    }
}
