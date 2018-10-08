using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Model;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsCommon.Get, "PnPException")]
    [CmdletHelp("Returns the last exception that occured",
        @"Returns the last exception which can be used while debugging PnP Cmdlets",
        Category = CmdletHelpCategory.Base)]
    [CmdletExample(
        Code = @"PS:> Get-PnPException",
        Remarks = "Returns the last exception",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPException -All",
        Remarks = "Returns all exceptions that occurred",
        SortOrder = 2)]
    public class GetException : PSCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Show all exceptions")]
        public SwitchParameter All;

        protected override void ProcessRecord()
        {
            var exceptions = (ArrayList)this.SessionState.PSVariable.Get("error").Value;
            if (exceptions.Count > 0)
            {
                var output = new List<PnPException>();
                if (All.IsPresent)
                {
                    foreach (ErrorRecord exception in exceptions)
                    {
                        output.Add(new PnPException() { Message = exception.Exception.Message, Stacktrace = exception.Exception.StackTrace, ScriptLineNumber = exception.InvocationInfo.ScriptLineNumber, InvocationInfo = exception.InvocationInfo });
                    }
                }
                else
                {
                    var exception = (ErrorRecord)exceptions[0];
                    output.Add(new PnPException() { Message = exception.Exception.Message, Stacktrace = exception.Exception.StackTrace, ScriptLineNumber = exception.InvocationInfo.ScriptLineNumber, InvocationInfo = exception.InvocationInfo });
                }
                WriteObject(output, true);
            }
        }
    }
}
