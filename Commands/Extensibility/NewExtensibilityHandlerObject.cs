using System.Management.Automation;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace SharePointPnP.PowerShell.Commands.Features
{
    [Cmdlet(VerbsCommon.New, "SPOExtensbilityHandlerObject")]
    [CmdletHelp("Creates an ExtensibilityHandler Object, to be used by the Get-SPOProvisioningTemplate cmdlet", Category = CmdletHelpCategory.Features)]
    [CmdletExample(
        Code = @"
PS:> $handler = New-SPOExtensibilityHandlerObject -Assembly Contoso.Core.Handlers -Type Contoso.Core.Handlers.MyExtensibilityHandler
PS:> Get-SPOProvisioningTemplate -Out NewTemplate.xml -ExtensibilityHandlers $handler",
        Remarks = @"This will create a new ExtensibilityHandler object that is run during extraction of the template", 
        SortOrder = 1)]
  
    public class NewExtensibilityHandlerObject : PSCmdlet
    {
        [Parameter(Mandatory = true, Position=0, ValueFromPipeline=true, HelpMessage = "The full assembly name of the handler")]
        public string Assembly;

        [Parameter(Mandatory = true, HelpMessage = "The type of the handler")]
        public string Type;

        [Parameter(Mandatory = false, HelpMessage = "Any configuration data you want to send to the handler")]
        public string Configuration;

        [Parameter(Mandatory = false, HelpMessage = "If set, the handler will be disabled")]
        public SwitchParameter Disabled;


        protected override void ProcessRecord()
        {
            ExtensibilityHandler handler = new ExtensibilityHandler();
            handler.Assembly = Assembly;
            handler.Type = Type;
            handler.Configuration = Configuration;
            handler.Enabled = !Disabled;
            WriteObject(handler);
        }

    }
}
