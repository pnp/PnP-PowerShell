#if !ONPREMISES
using System.Collections.Generic;
using System.Management.Automation;
using Newtonsoft.Json.Linq;
using OfficeDevPnP.Core.Framework.Graph;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using SharePointPnP.PowerShell.Commands.Base;
using SharePointPnP.PowerShell.Commands.Model;

namespace SharePointPnP.PowerShell.Commands.ManagementApi
{
    [Cmdlet(VerbsCommon.Get, "PnPOffice365Services")]
    [CmdletHelp(
        "Gets the services available in Office 365 from the Office 365 Management API",
        Category = CmdletHelpCategory.ManagementApi,
        OutputTypeLink = "https://docs.microsoft.com/office/office-365-management-api/office-365-service-communications-api-reference#get-services",
        SupportedPlatform = CmdletSupportedPlatform.Online)]
    [CmdletExample(
       Code = "PS:> Get-PnPOffice365Services",
       Remarks = "Retrieves the current services available in Office 365",
       SortOrder = 1)]
    [CmdletOfficeManagementApiPermission(OfficeManagementApiPermission.ServiceHealth_Read)]
    public class GetOffice365Services : PnPOfficeManagementApiCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var response = GraphHttpClient.MakeGetRequestForString($"{ApiRootUrl}ServiceComms/Services", AccessToken);
            var servicesJson = JObject.Parse(response);
            var services = servicesJson["value"].ToObject<IEnumerable<ManagementApiService>>();

            WriteObject(services, true);
        }
    }
}
#endif