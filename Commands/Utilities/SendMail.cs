using System.Management.Automation;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.Core.Utilities;

namespace SharePointPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommunications.Send, "SPOMail")]
    [CmdletHelp("Sends an email using the Office 365 SMTP Service",
        Category = CmdletHelpCategory.Utilities)]
    [CmdletExample(
        Code = @"PS:> Send-SPOMail -To address@tenant.sharepointonline.com -Subject test -Body test",
        Remarks = @"Sends an e-mail using the SharePoint SendEmail method using the current context. E-mail is sent from the system account and can only be sent to accounts in the same tenant", SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Send-SPOMail -To address@contoso.com -Subject test -Body test -From me@tenant.onmicrosoft.com -Password xyz",
        Remarks = @"Sends an e-mail via Office 365 SMTP and requires from address and password. E-mail is sent from the from user and can be sent to both internal and external addresses.", SortOrder = 2)]
    public class SendMail : SPOWebCmdlet
    {
        [Parameter(Mandatory = false)]
        public string Server = "smtp.office365.com";

        [Parameter(Mandatory = false, HelpMessage = "If using from address, you also have to provide a password")]
        public string From;

        [Parameter(Mandatory = false, HelpMessage = "If using a password, you also have to provide the associated from address")]
        public string Password;

        [Parameter(Mandatory = true)]
        public string[] To;

        [Parameter(Mandatory = false)]
        public string[] Cc;

        [Parameter(Mandatory = true)]
        public string Subject;

        [Parameter(Mandatory = true)]
        public string Body;
        
        protected override void ExecuteCmdlet()
        {
            if (string.IsNullOrWhiteSpace(Password) && string.IsNullOrWhiteSpace(From))
            {
                MailUtility.SendEmail(this.ClientContext, To, Cc, Subject, Body);
            }
            else
            {
                MailUtility.SendEmail(Server, From, Password, To, Cc, Subject, Body);
            }
        }
    }
}
