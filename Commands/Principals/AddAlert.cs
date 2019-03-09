#if !ONPREMISES
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;

namespace SharePointPnP.PowerShell.Commands.Principals
{
    public enum AlertFilter
    {
        AnythingChanges = 0,
        SomeoneElseChangesAnItem = 1,
        SomeoneElseChangesItemCreatedByMe = 2,
        SomeoneElseChangesItemLastModifiedByMe = 3
    }

    [Cmdlet(VerbsCommon.Add, "PnPAlert")]
    [CmdletHelp("Adds an alert for a user to a list",
        Category = CmdletHelpCategory.Principals,
        OutputType = typeof(AlertCreationInformation),
        OutputTypeLink = "https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.client.alertcreationinformation.aspx")]
    [CmdletExample(
        Code = @"Add-PnPAlert -List ""Demo List""",
        Remarks = @"Adds a new alert to the ""Demo List"" for the current user.",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"Add-PnPAlert -Title ""Daily summary"" -List ""Demo List"" -Frequency Daily -ChangeType All -Time (Get-Date -Hour 11 -Minute 00 -Second 00)",
        Remarks = @"Adds a daily alert for the current user at the given time to the ""Demo List"". Note: a timezone offset might be applied so please verify on your tenant that the alert indeed got the right time.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"Add-PnPAlert -Title ""Alert for user"" -List ""Demo List"" -Identity ""i:0#.f|membership|Alice@contoso.onmicrosoft.com""",
        Remarks = @"Adds a new alert for user ""Alice"" to the ""Demo List"". Note: Only site owners and admins are permitted to set alerts for other users.",
        SortOrder = 3)]
    public class AddAlert : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The ID, Title or Url of the list.")]
        public ListPipeBind List;

        [Parameter(Mandatory = false, HelpMessage = "Alert title")]
        public string Title { get; set; } = "Alert";

        [Parameter(Mandatory = false, HelpMessage = "User to create the alert for (User ID, login name or actual User object). Skip this parameter to create an alert for the current user. Note: Only site owners can create alerts for other users.")]
        public UserPipeBind Identity;

        [Parameter(Mandatory = false, HelpMessage = "Alert delivery method")]
        public AlertDeliveryChannel DeliveryMethod { get; set; } = AlertDeliveryChannel.Email;

        [Parameter(Mandatory = false, HelpMessage = "Alert change type")]
        public AlertEventType ChangeType { get; set; } = AlertEventType.All;

        [Parameter(Mandatory = false, HelpMessage = "Alert frequency")]
        public AlertFrequency Frequency { get; set; } = AlertFrequency.Immediate;

        [Parameter(Mandatory = false, HelpMessage = @"Alert filter")]
        public AlertFilter Filter { get; set; } = AlertFilter.AnythingChanges;

        [Parameter(Mandatory = false, HelpMessage = "Alert time (if frequency is not immediate)")]
        public DateTime Time { get; set; } = DateTime.MinValue;

        private User GetUserFromPipeBind()
        {
            if (Identity == null)
            {
                return null;
            }

            // note: the following code to get the user is copied from Remove-PnPUser - it could be put into a utility class
            var retrievalExpressions = new Expression<Func<User, object>>[]
            {
                u => u.Id,
                u => u.LoginName,
                u => u.Email
            };

            User user = null;
            if (Identity.User != null)
            {
                WriteVerbose($"Received user instance {Identity.Login}");
                user = Identity.User;
            }
            else if (Identity.Id > 0)
            {
                WriteVerbose($"Retrieving user by Id {Identity.Id}");
                user = ClientContext.Web.GetUserById(Identity.Id);
            }
            else if (!string.IsNullOrWhiteSpace(Identity.Login))
            {
                WriteVerbose($"Retrieving user by LoginName {Identity.Login}");
                user = ClientContext.Web.SiteUsers.GetByLoginName(Identity.Login);
            }
            if (ClientContext.HasPendingRequest)
            {
                ClientContext.Load(user, retrievalExpressions);
                ClientContext.ExecuteQueryRetry();
            }

            return user;
        }

        protected override void ExecuteCmdlet()
        {
            List list = null;
            if (List != null)
            {
                list = List.GetList(SelectedWeb);
            }
            if (list != null)
            {
                var alert = new AlertCreationInformation();

                User user;
                if (null != Identity)
                {
                    user = GetUserFromPipeBind();
                    if (user == null)
                    {
                        throw new ArgumentException("Unable to find user", "Identity");
                    }
                }
                else
                {
                    user = SelectedWeb.CurrentUser;
                }

                alert.AlertFrequency = Frequency;
                alert.AlertType = AlertType.List;
                alert.AlwaysNotify = false;
                alert.DeliveryChannels = DeliveryMethod;
                var filterValue = Convert.ChangeType(Filter, Filter.GetTypeCode()).ToString();
                alert.Filter = filterValue;

                // setting the value of Filter sometimes does not work (CSOM < Jan 2017, ...?), so we use a known workaround
                // reference: http://toddbaginski.com/blog/how-to-create-office-365-sharepoint-alerts-with-the-client-side-object-model-csom/
                var properties = new Dictionary<string, string>()
                {
                    { "FilterIndex", filterValue }
                    //Send Me an alert when:
                    // 0 = Anything Changes
                    // 1 = Someone else changes a document
                    // 2 = Someone else changes a document created by me
                    // 3 = Someone else changes a document modified by me
                };
                alert.Properties = properties;

                alert.List = list;
                alert.Status = AlertStatus.On;
                alert.Title = Title;
                alert.User = user;
                alert.EventType = ChangeType;
                if (Time != DateTime.MinValue)
                {
                    alert.AlertTime = Time;
                }

                user.Alerts.Add(alert);
                ClientContext.ExecuteQueryRetry();
                WriteObject(alert);
            }
            else
            {
                throw new ArgumentException("Unable to find list", "List");
            }
        }
    }
}
#endif