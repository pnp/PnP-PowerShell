using System.Management.Automation;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using System;
using OfficeDevPnP.PowerShell.Commands.Properties;

namespace OfficeDevPnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsCommon.Get, "SPOContext")]
    [CmdletHelp("Returns a Client Side Object Model context",
        Category = CmdletHelpCategory.Base)]
    [CmdletExample(
        Code = @"PS:> $ctx = Get-SPOContext",
        Remarks = @"This will put the current context in the $ctx variable.",
        SortOrder = 1)]        
    public class GetSPOContext : PSCmdlet
    {

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            if (SPOnlineConnection.CurrentConnection == null)
            {
                throw new InvalidOperationException(Resources.NoConnection);
            }
            if (SPOnlineConnection.CurrentConnection.Context == null)
            {
                throw new InvalidOperationException(Resources.NoConnection);
            }
        }

        protected override void ProcessRecord()
        {
            WriteObject(SPOnlineConnection.CurrentConnection.Context);
        }
    }
}
