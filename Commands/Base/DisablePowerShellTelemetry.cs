using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
#if NETSTANDARD2_0
using System.IdentityModel.Tokens.Jwt;
#else
using System.IdentityModel.Tokens;
#endif
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet(VerbsLifecycle.Disable, "PnPPowerShellTelemetry")]
    [CmdletHelp("Disables PnP PowerShell telemetry tracking",
        "Disables PnP PowerShell telemetry tracking",
        Category = CmdletHelpCategory.TenantAdmin)]
    [CmdletExample(
       Code = "PS:> Disable-PnPPowerShellTelemetry",
       Remarks = "Will prompt you to confirm to disable telemetry tracking.",
       SortOrder = 1)]
    public class DisablePowerShellTelemetry : PSCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Specifying the Force parameter will skip the confirmation question.")]
        public SwitchParameter Force;

        protected override void ProcessRecord()
        {
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var telemetryFile = System.IO.Path.Combine(userProfile, ".pnppowershelltelemetry");
            if (Force || ShouldContinue("Do you want to disable telemetry for PnP PowerShell?", "Confirm"))
            {
                System.IO.File.WriteAllText(telemetryFile, "disallow");
                SPOnlineConnection.CurrentConnection.TelemetryClient = null;
                WriteObject("Telemetry disabled");
            }
            else
            {
                var enabled = false;
                if (System.IO.File.Exists(telemetryFile))
                {
                    enabled = System.IO.File.ReadAllText(telemetryFile).ToLower() == "allow";
                }
                WriteObject($"Telemetry setting unchanged: currently {(enabled ? "enabled" : "disabled")}");
            }
        }
    }
}