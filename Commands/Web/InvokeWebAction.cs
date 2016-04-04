using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.InvokeAction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet("Invoke", "SPOWebAction")]
    [CmdletHelp("Executes operations on web, lists, list items.",
        Category = CmdletHelpCategory.Webs)]
    [CmdletExample(
        Code = @"PS:> Invoke-SPOWebAction -ListAction ${function:ListAction}",
        Remarks = "This will call the function ListAction on all the lists located on the current web.",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Invoke-SPOWebAction -ShouldProcessListAction ${function:ShouldProcessGroupList} -ListAction ${function:UpdateGroupListFields}",
        Remarks = "This will call the function ShouldProcessGroupList, if it returns true the function ListAction will then be called. This will occur on all lists located on the current web",
        SortOrder = 2)]
    public class InvokeWebAction : SPOWebCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Webs you want to process (for example diffrent site collections)")]
        public Web[] Webs;

        [Parameter(Mandatory = false, HelpMessage = "Function to be exectued on the web.")]
        public Action<Web> WebAction;

        [Parameter(Mandatory = false, HelpMessage = "Function to be executed on the web that would decide if " + nameof(WebAction) + " should be invoked")]
        public Func<Web, bool> ShouldProcessWebAction;

        [Parameter(Mandatory = false, HelpMessage = "Function to be exectued on the web, this will trigger after lists and list items have been proccessed")]
        public Action<Web> PostWebAction;

        [Parameter(Mandatory = false, HelpMessage = "Function to be executed on the web that would decide if " + nameof(PostWebAction) + " should be invoked")]
        public Func<Web, bool> ShouldProcessPostWebAction;

        [Parameter(Mandatory = false, HelpMessage = "The properties to load for web.")]
        public string[] WebProperties;

        [Parameter(Mandatory = false, HelpMessage = "Function to be exectued on the list")]
        public Action<List> ListAction;

        [Parameter(Mandatory = false, HelpMessage = "Function to be executed on the web that would decide if " + nameof(ListAction) + " should be invoked")]
        public Func<List, bool> ShouldProcessListAction;

        [Parameter(Mandatory = false, HelpMessage = "Function to be exectued on the list, this will trigger after list items have been proccesse")]
        public Action<List> PostListAction;

        [Parameter(Mandatory = false, HelpMessage = "Function to be executed on the web that would decide if " + nameof(PostListAction) + " should be invoked")]
        public Func<List, bool> ShouldProcessPostListAction;

        [Parameter(Mandatory = false, HelpMessage = "The properties to load for list.")]
        public string[] ListProperties;

        [Parameter(Mandatory = false, HelpMessage = "Function to be exectued on the list item")]
        public Action<ListItem> ListItemAction;

        [Parameter(Mandatory = false, HelpMessage = "Function to be executed on the web that would decide if " + nameof(ListItemAction) + " should be invoked")]
        public Func<ListItem, bool> ShouldProcessListItemAction;

        [Parameter(Mandatory = false, HelpMessage = "The properties to load for list items.")]
        public string[] ListItemProperties;

        [Parameter(Mandatory = false, HelpMessage = "Specify if sub webs will be processed")]
        public SwitchParameter SubWebs;

        protected override void ExecuteCmdlet()
        {
            if (WebAction == null && ListAction == null && ListItemAction == null && PostWebAction == null && PostListAction == null)
            {
                WriteError(new ErrorRecord(new ArgumentNullException("An action need to be specified"), "0", ErrorCategory.InvalidArgument, null));
                return;
            }

            InvokeAction.InvokeAction invokeAction = new InvokeAction.InvokeAction(this);

            IEnumerable<Web> websToProcess;
            if (Webs == null || Webs.Length == 0)
                websToProcess = new[] { SelectedWeb };
            else
                websToProcess = Webs;

            InvokeActionParameter<Web> webActions = new InvokeActionParameter<Web>()
            {
                Action = WebAction,
                ShouldProcessAction = ShouldProcessWebAction,
                PostAction = PostWebAction,
                ShouldProcessPostAction = ShouldProcessPostWebAction,
                Properties = WebProperties
            };

            InvokeActionParameter<List> listActions = new InvokeActionParameter<List>()
            {
                Action = ListAction,
                ShouldProcessAction = ShouldProcessListAction,
                PostAction = PostListAction,
                ShouldProcessPostAction = ShouldProcessPostListAction,
                Properties = ListProperties
            };

            InvokeActionParameter<ListItem> listItemActions = new InvokeActionParameter<ListItem>()
            {
                Action = ListItemAction,
                ShouldProcessAction = ShouldProcessListItemAction,
                Properties = WebProperties
            };

            invokeAction.StartProcessAction(websToProcess, SubWebs.ToBool(), webActions, listActions, listItemActions);
        }
    }
}