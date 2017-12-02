#if !SP2013
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.WebParts;
using OfficeDevPnP.Core.Utilities;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base.PipeBinds;
using OfficeDevPnP.Core.Pages;

namespace SharePointPnP.PowerShell.Commands.WebParts
{
    [Cmdlet(VerbsCommon.Get, "PnPClientSideWebPart")]
    [CmdletHelp("Retrieve one or more Client-Side Web Parts from a page",
        Category = CmdletHelpCategory.WebParts,
        SupportedPlatform = CmdletSupportedPlatform.SP2016)]
    [CmdletExample(
        Code = @"PS:> Get-PnPClientSideWebPart -Page Home",
        Remarks = @"Returns all webparts defined on the given page.", SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Get-PnPClientSideWebPart -Page Home -Identity a2875399-d6ff-43a0-96da-be6ae5875f82",
        Remarks = @"Returns a specific webpart defined on the given page.", SortOrder = 2)]
    public class GetClientSideWebPart : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0, HelpMessage = "The name of the page")]
        public ClientSidePagePipeBind Page;

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The identity of the webpart. This can be the webpart instance id or the title of a webpart")]
        public ClientSideWebPartPipeBind Identity;

        protected override void ExecuteCmdlet()
        {
            var clientSidePage = Page.GetPage(ClientContext);

            if (clientSidePage == null)
                throw new Exception($"Page '{Page?.Name}' does not exist");

            if(!MyInvocation.BoundParameters.ContainsKey("Identity"))
            {
                WriteObject(clientSidePage.Controls.Where(c => c.GetType() == typeof(ClientSideWebPart)), true);
            } else
            {
                WriteObject(Identity.GetWebPart(clientSidePage), true);
            }

        }
    }
}
#endif