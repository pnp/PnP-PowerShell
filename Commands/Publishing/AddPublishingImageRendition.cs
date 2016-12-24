using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.Publishing
{
    [Cmdlet(VerbsCommon.Add, "PnPPublishingImageRendition")]
    [CmdletHelp("Adds an Image Rendition", Category = CmdletHelpCategory.Publishing)]
    [CmdletExample(
        Code = @"PS:> Add-PnPPublishingImageRendition -ImageRenditionName ""MyImageRendition"" -Width 800 -Height 600",
        Remarks = @"Adds an Image Rendition.",
        SortOrder = 1)]
    public class AddPublishingImageRendition : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The display name of the Image Rendition.")]
        public string imageRenditionName = string.Empty;

        [Parameter(Mandatory = true, HelpMessage = "The width of the Image Rendition.")]
        public int imageRenditionWidth = 0;
        
        [Parameter(Mandatory = true, HelpMessage = "The height of the Image Rendition.")]
        public int imageRenditionHeight = 0;

        protected override void ExecuteCmdlet()
        {
            SelectedWeb.AddPublishingImageRendition(imageRenditionName, imageRenditionWidth, imageRenditionHeight);
        }
    }
}
