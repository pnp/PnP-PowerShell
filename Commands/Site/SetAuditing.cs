using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "SPOAuditing")]
    [CmdletHelp("Set Auditing setting for a site",
        Category = CmdletHelpCategory.Sites)]
    [CmdletExample(
        Code = @"PS:> Set-SPOAuditing -EnableAll",
        Remarks = "Enables all auditing settings for the current site",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Set-SPOAuditing -DisableAll",
        Remarks = @"Disables all auditing settings for the current site
                    This also disables the automatic trimming of the audit log",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Set-SPOAuditing -RetentionTime 7",
        Remarks = "Sets the audit log trimming to 7 days, this also enables the automatic trimming of the audit log",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Set-SPOAuditing -TrimAuditLog",
        Remarks = "Enables the automatic trimming of the audit log",
        SortOrder = 4)]
    public class SetAuditing : SPOCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName ="EnableAll")]
        public SwitchParameter EnableAll;
        [Parameter(Mandatory = false, ParameterSetName = "DisableAll")]
        public SwitchParameter DisableAll;

        [Parameter(Mandatory = false, ParameterSetName = "Other")]
        [Parameter(ParameterSetName = "EnableAll")]
        public int RetentionTime = -1;
        [Parameter(Mandatory = false, ParameterSetName = "Other")]
        [Parameter(ParameterSetName = "EnableAll")]
        public SwitchParameter TrimAuditLog;

        //Editing items
        //AuditMaskType.Update
        [Parameter(Mandatory = false, ParameterSetName = "Other")]
        public SwitchParameter EditItems;

        //Checking out or checking in items
        //AuditMaskType.CheckOut and AuditMaskType.CheckIn
        [Parameter(Mandatory = false, ParameterSetName = "Other")]
        public SwitchParameter CheckOutCheckInItems;

        //Moving or copying items to another location in the site
        //AuditMaskType.Copy and AuditMaskType.Move
        [Parameter(Mandatory = false, ParameterSetName = "Other")]
        public SwitchParameter MoveCopyItems;

        //Deleting or restoring items
        //AuditMaskType.Undelete and AuditMaskType.ObjectDelete
        [Parameter(Mandatory = false, ParameterSetName = "Other")]
        public SwitchParameter DeleteRestoreItems;

        //Editing content types and columns
        //AuditMaskType.SchemaChange and AuditMaskType.ProfileChange
        [Parameter(Mandatory = false, ParameterSetName = "Other")]
        public SwitchParameter EditContentTypesColumns;

        //Searching site content
        //AuditMaskType.Search
        [Parameter(Mandatory = false, ParameterSetName = "Other")]
        public SwitchParameter SearchContent;

        //Editing users and permissions
        //AuditMaskType.SecurityChange
        [Parameter(Mandatory = false, ParameterSetName = "Other")]
        public SwitchParameter EditUsersPermissions;

        protected override void ExecuteCmdlet()
        {
            var UpdateAudit = false;
            var audit = ClientContext.Site.Audit;
            var AuditFlags = audit.AuditFlags;
            ClientContext.Load(audit);
            ClientContext.ExecuteQueryRetry();

            if (EnableAll)
            {
                AuditFlags = AuditMaskType.All;
                UpdateAudit = true;
            }
            if(DisableAll)
            {
                AuditFlags = AuditMaskType.None;
                UpdateAudit = true;
                ClientContext.Site.TrimAuditLog = false;
            }
            if(RetentionTime != -1)
            {
                ClientContext.Site.AuditLogTrimmingRetention = RetentionTime;
                ClientContext.Site.TrimAuditLog = true;
            }
            if(TrimAuditLog)
            {
                ClientContext.Site.TrimAuditLog = false;
            }

            //set the events to audit
            //AuditMaskType.Update
            if (EditItems) { AuditFlags = AuditFlags | AuditMaskType.Update; }

            //AuditMaskType.CheckOut and AuditMaskType.CheckIn
            if(CheckOutCheckInItems) { AuditFlags = AuditFlags | AuditMaskType.CheckOut | AuditMaskType.CheckIn; }

            //AuditMaskType.Copy and AuditMaskType.Move
            if (MoveCopyItems) { AuditFlags = AuditFlags | AuditMaskType.Copy | AuditMaskType.Move; }

            //AuditMaskType.Undelete and AuditMaskType.ObjectDelete
            if (DeleteRestoreItems) { AuditFlags = AuditFlags | AuditMaskType.Undelete | AuditMaskType.ObjectDelete; }

            //AuditMaskType.SchemaChange and AuditMaskType.ProfileChange
            if (EditContentTypesColumns) { AuditFlags = AuditFlags | AuditMaskType.SchemaChange | AuditMaskType.ProfileChange; }

            //AuditMaskType.Search
            if (SearchContent) { AuditFlags = AuditFlags | AuditMaskType.Search; }

            //AuditMaskType.SecurityChange
            if (EditUsersPermissions) { AuditFlags = AuditFlags | AuditMaskType.SecurityChange; }

            if(UpdateAudit)
            {
                ClientContext.Site.Audit.AuditFlags = AuditFlags;
                ClientContext.Site.Audit.Update();
            }

            //Commit the changes
            ClientContext.ExecuteQueryRetry();
        }
    }
}
