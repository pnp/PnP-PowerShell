using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.PowerShell.CmdletHelpAttributes;
using OfficeDevPnP.PowerShell.Commands.Enums;
using System.Linq;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Add, "SPOCustomAction")]
    [CmdletHelp("Adds a custom action to a web", Category = CmdletHelpCategory.Branding)]
    public class AddCustomAction : SPOWebCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name = string.Empty;

        [Parameter(Mandatory = true)]
        public string Title = string.Empty;

        [Parameter(Mandatory = true)]
        public string Description = string.Empty;

        [Parameter(Mandatory = true)]
        public string Group = string.Empty;

        [Parameter(Mandatory = true)]
        public string Location = string.Empty;

        [Parameter(Mandatory = false)]
        public int Sequence = 0;

        [Parameter(Mandatory = false)]
        public string Url = string.Empty;

        [Parameter(Mandatory = false)]
        public string ImageUrl = string.Empty;

        [Parameter(Mandatory = false)]
        public string CommandUIExtension = string.Empty;

        [Parameter(Mandatory = false)]
        public string RegistrationId = string.Empty;

        [Parameter(Mandatory = false)]
        public PermissionKind[] Rights;

        [Parameter(Mandatory = false)]
        public UserCustomActionRegistrationType RegistrationType;

        [Parameter(Mandatory = false)]
        public CustomActionScope Scope = CustomActionScope.Web;


        protected override void ExecuteCmdlet()
        {
            var permissions = new BasePermissions();
            if (Rights != null)
            {
                foreach (var kind in Rights)
                {
                    permissions.Set(kind);
                }
            }

            var ca = new CustomActionEntity
            {
                Name = Name,
                ImageUrl = ImageUrl,
                CommandUIExtension = CommandUIExtension,
                RegistrationId = RegistrationId,
                RegistrationType = RegistrationType,
                Description = Description,
                Location = Location,
                Group = Group,
                Sequence = Sequence,
                Title = Title,
                Url = Url,
                Rights = permissions
            };

            if (Scope == CustomActionScope.Web)
            {
                SelectedWeb.AddCustomAction(ca);
            }
            else
            {
                ClientContext.Site.AddCustomAction(ca);
            }
        }
    }
}
