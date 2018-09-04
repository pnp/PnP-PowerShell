using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet("Apply", "PnPProvisioningHierarchy", SupportsShouldProcess = true)]
    [CmdletHelp("Adds a provisioning sequence object to a provisioning site object",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> Add-PnPProvisioningSequence -Hierarchy $myhierarchy -Sequence $mysequence",
       Remarks = "Adds an existing sequence object to an existing hierarchy object",
       SortOrder = 1)]
    [CmdletExample(
       Code = @"PS:> New-PnPProvisioningSequence -Id ""MySequence"" | Add-PnPProvisioningSequence -Hierarchy $hierarchy",
       Remarks = "Creates a new instance of a provisioning sequence object and sets the Id to the value specified, then the sequence is added to an existing hierarchy object",
       SortOrder = 2)]
    public class ApplyProvisioningHierarchy : PnPAdminCmdlet
    {
        private ProgressRecord progressRecord = new ProgressRecord(0, "Activity", "Status");
        private ProgressRecord subProgressRecord = new ProgressRecord(1, "Activity", "Status");

        [Parameter(Mandatory = true)]
        public ProvisioningHierarchy Hierarchy;

        [Parameter(Mandatory = false)]
        public string SequenceId;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to only process a specific part of the template. Notice that this might fail, as some of the handlers require other artifacts in place if they are not part of what your applying.", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public Handlers Handlers;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to run all handlers, excluding the ones specified.", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public Handlers ExcludeHandlers;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to specify ExtensbilityHandlers to execute while applying a template", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public ExtensibilityHandler[] ExtensibilityHandlers;

        [Parameter(Mandatory = false, HelpMessage = "Allows you to specify ITemplateProviderExtension to execute while applying a template.", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public ITemplateProviderExtension[] TemplateProviderExtensions;

        [Parameter(Mandatory = false, HelpMessage = "Specify this parameter if you want to overwrite and/or create properties that are known to be system entries (starting with vti_, dlc_, etc.)", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SwitchParameter OverwriteSystemPropertyBagValues;

        [Parameter(Mandatory = false, HelpMessage = "Ignore duplicate data row errors when the data row in the template already exists.", ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SwitchParameter IgnoreDuplicateDataRowErrors;

        [Parameter(Mandatory = false, HelpMessage = "If set content types will be provisioned if the target web is a subweb.")]
        public SwitchParameter ProvisionContentTypesToSubWebs;

        [Parameter(Mandatory = false, HelpMessage = "If set fields will be provisioned if the target web is a subweb.")]
        public SwitchParameter ProvisionFieldsToSubWebs;

        [Parameter(Mandatory = false, HelpMessage = "Override the RemoveExistingNodes attribute in the Navigation elements of the template. If you specify this value the navigation nodes will always be removed before adding the nodes in the template")]
        public SwitchParameter ClearNavigation;

        protected override void ExecuteCmdlet()
        {
            var applyingInformation = new ProvisioningTemplateApplyingInformation();

            if (MyInvocation.BoundParameters.ContainsKey("Handlers"))
            {
                applyingInformation.HandlersToProcess = Handlers;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ExcludeHandlers"))
            {
                foreach (var handler in (Handlers[])Enum.GetValues(typeof(Handlers)))
                {
                    if (!ExcludeHandlers.Has(handler) && handler != Handlers.All)
                    {
                        Handlers = Handlers | handler;
                    }
                }
                applyingInformation.HandlersToProcess = Handlers;
            }

            if (ExtensibilityHandlers != null)
            {
                applyingInformation.ExtensibilityHandlers = ExtensibilityHandlers.ToList();
            }

            applyingInformation.ProgressDelegate = (message, step, total) =>
            {
                if (message != null)
                {
                    var percentage = Convert.ToInt32((100 / Convert.ToDouble(total)) * Convert.ToDouble(step));
                    progressRecord.Activity = $"Applying template to tenant";
                    progressRecord.StatusDescription = message;
                    progressRecord.PercentComplete = percentage;
                    progressRecord.RecordType = ProgressRecordType.Processing;
                    WriteProgress(progressRecord);
                }
            };

            var warningsShown = new List<string>();

            applyingInformation.MessagesDelegate = (message, type) =>
            {
                switch (type)
                {
                    case ProvisioningMessageType.Warning:
                        {
                            if (!warningsShown.Contains(message))
                            {
                                WriteWarning(message);
                                warningsShown.Add(message);
                            }
                            break;
                        }
                    case ProvisioningMessageType.Progress:
                        {
                            if (message != null)
                            {
                                var activity = message;
                                if (message.IndexOf("|") > -1)
                                {
                                    var messageSplitted = message.Split('|');
                                    if (messageSplitted.Length == 4)
                                    {
                                        var current = double.Parse(messageSplitted[2]);
                                        var total = double.Parse(messageSplitted[3]);
                                        subProgressRecord.RecordType = ProgressRecordType.Processing;
                                        subProgressRecord.Activity = string.IsNullOrEmpty(messageSplitted[0]) ? "-" : messageSplitted[0];
                                        subProgressRecord.StatusDescription = string.IsNullOrEmpty(messageSplitted[1]) ? "-" : messageSplitted[1];
                                        subProgressRecord.PercentComplete = Convert.ToInt32((100 / total) * current);
                                        WriteProgress(subProgressRecord);
                                    }
                                    else
                                    {
                                        subProgressRecord.Activity = "Processing";
                                        subProgressRecord.RecordType = ProgressRecordType.Processing;
                                        subProgressRecord.StatusDescription = activity;
                                        subProgressRecord.PercentComplete = 0;
                                        WriteProgress(subProgressRecord);
                                    }
                                }
                                else
                                {
                                    subProgressRecord.Activity = "Processing";
                                    subProgressRecord.RecordType = ProgressRecordType.Processing;
                                    subProgressRecord.StatusDescription = activity;
                                    subProgressRecord.PercentComplete = 0;
                                    WriteProgress(subProgressRecord);
                                }
                            }
                            break;
                        }
                    case ProvisioningMessageType.Completed:
                        {

                            WriteProgress(new ProgressRecord(1, message, " ") { RecordType = ProgressRecordType.Completed });
                            break;
                        }
                }
            };

            applyingInformation.OverwriteSystemPropertyBagValues = OverwriteSystemPropertyBagValues;
            applyingInformation.IgnoreDuplicateDataRowErrors = IgnoreDuplicateDataRowErrors;
            applyingInformation.ClearNavigation = ClearNavigation;
            applyingInformation.ProvisionContentTypesToSubWebs = ProvisionContentTypesToSubWebs;
            applyingInformation.ProvisionFieldsToSubWebs = ProvisionFieldsToSubWebs;

            Tenant.ApplyProvisionHierarchy(Hierarchy, SequenceId, applyingInformation);
          
        }
    }
}
