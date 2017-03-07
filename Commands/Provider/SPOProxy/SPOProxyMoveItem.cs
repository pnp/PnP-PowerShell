using System.Management.Automation;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Provider.SPOProxy
{
    [Cmdlet(CmdletVerb, CmdletNoun, DefaultParameterSetName = "Path", SupportsShouldProcess = true, SupportsTransactions = true)]
    [CmdletHelp("Proxy cmdlet for using Move-Item between SharePoint provider and FileSystem provider", Category = CmdletHelpCategory.Files)]
    public class SPOProxyMoveItem : SPOProxyCmdletBase
    {
        public const string CmdletVerb = "Move";

        internal override string CmdletType => CmdletVerb;

        public override SwitchParameter Recurse => true;

        protected override void ProcessRecord()
        {
            SPOProxyImplementation.CopyMoveImlementation(this);
        }
    }
}
