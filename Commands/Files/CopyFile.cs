using System;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using Resources = SharePointPnP.PowerShell.Commands.Properties.Resources;
using OfficeDevPnP.Core.Utilities;
using File = Microsoft.SharePoint.Client.File;

namespace SharePointPnP.PowerShell.Commands.Files
{
    [Cmdlet(VerbsCommon.Copy, "PnPFile", SupportsShouldProcess = true)]
    [CmdletAlias("Copy-SPOFile")]
    [CmdletHelp("Copies a file or folder to a different location",
        Category = CmdletHelpCategory.Files)]
    [CmdletExample(
        Remarks = "Copies a file named company.docx located in a document library called Documents in the projects sitecollection to the site collection otherproject. If a file named company.aspx already exists, it won't perform the copy.",
        Code = @"PS:>Copy-PnPFile -ServerRelativeUrl /sites/project/Documents/company.docx -TargetUrl /sites/otherproject/Documents/company.docx",
        SortOrder = 1)]
    [CmdletExample(
        Remarks = "Copies a file named company.docx located in a document library called Documents in the current site to the Documents library in the site collection otherproject. If a file named company.aspx already exists, it won't perform the copy.",
        Code = @"PS:>Copy-PnPFile -SiteRelativeUrl Documents/company.aspx -TargetUrl /sites/otherproject/Documents/company.docx",
        SortOrder = 2)]
    [CmdletExample(
        Remarks = "Copies a file named company.docx located in a document library called Documents in the projects sitecollection to the site collection otherproject. If a file named company.aspx already exists, it will still perform the copy and replace the original company.aspx file.",
        Code = @"PS:>Copy-PnPFile -ServerRelativeUrl /sites/project/Documents/company.docx -TargetUrl /sites/otherproject/Documents/company.docx -OverwriteIfAlreadyExists",
        SortOrder = 3)]
    [CmdletExample(
        Remarks = "Copies a folder named MyDocs in the document library called Documents located in the projects sitecollection to the site collection otherproject. If the MyDocs folder exist it will copy into it, if not it will be created.",
        Code = @"PS:>Copy-PnPFile -ServerRelativeUrl /sites/project/Documents/MyDocs -TargetUrl /sites/otherproject/Documents -OverwriteIfAlreadyExists",
        SortOrder = 4)]
    [CmdletExample(
        Remarks = "Copies a folder named MyDocs in the document library called Documents located in the projects sitecollection to the root folder of the library named Documents in the site collection otherproject.",
        Code = @"PS:>Copy-PnPFile -ServerRelativeUrl /sites/project/Documents/MyDocs -TargetUrl /sites/otherproject/Documents -SkipSourceFolderName -OverwriteIfAlreadyExists",
        SortOrder = 5)]
    [CmdletExample(
        Remarks = "Copies a folder named MyDocs in the MyDocs folder of the library named Documents. If the MyDocs folder does not exists, it will be created.",
        Code = @"PS:>Copy-PnPFile -ServerRelativeUrl /sites/project/Documents/MyDocs -TargetUrl /sites/otherproject/Documents/MyDocs -SkipSourceFolderName -OverwriteIfAlreadyExists",
        SortOrder = 6)]
    [CmdletExample(
        Remarks = "Copies a folder named MyDocs in the root of the library named Documents. If the MyDocs folder exists in the target, a subfolder also named MyDocs is created.",
        Code = @"PS:>Copy-PnPFile -ServerRelativeUrl /sites/project/Documents/MyDocs -TargetUrl /sites/otherproject/Documents/MyDocs -OverwriteIfAlreadyExists",
        SortOrder = 7)]

    public class CopyFile : SPOWebCmdlet
    {
        private ProgressRecord _progressFolder = new ProgressRecord(0, "Activity", "Status") { Activity = "Copying folder" };
        private ProgressRecord _progressFile = new ProgressRecord(1, "Activity", "Status") { Activity = "Copying file" };

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "SERVER", HelpMessage = "Server relative Url specifying the file to move. Must include the file name.")]
        public string ServerRelativeUrl = string.Empty;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "SITE", HelpMessage = "Site relative Url specifying the file to move. Must include the file name.")]
        public string SiteRelativeUrl = string.Empty;

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "Server relative Url where to copy the file to. Must include the file name.")]
        public string TargetUrl = string.Empty;

        [Parameter(Mandatory = false, HelpMessage = "If provided, if a file already exists at the TargetUrl, it will be overwritten. If ommitted, the copy operation will be canceled if the file already exists at the TargetUrl location.")]
        public SwitchParameter OverwriteIfAlreadyExists;

        [Parameter(Mandatory = false, HelpMessage = "If provided, no confirmation will be requested and the action will be performed")]
        public SwitchParameter Force;

        [Parameter(Mandatory = false, HelpMessage = "If the source is a folder, the source folder name will not be created, only the contents within it.")]
        public SwitchParameter SkipSourceFolderName;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSetName == "SITE")
            {
                var webUrl = SelectedWeb.EnsureProperty(w => w.ServerRelativeUrl);
                ServerRelativeUrl = UrlUtility.Combine(webUrl, SiteRelativeUrl);
            }

            var file = SelectedWeb.GetFileByServerRelativeUrl(ServerRelativeUrl);
            var folder = SelectedWeb.GetFolderByServerRelativeUrl(ServerRelativeUrl);
            ClientContext.Load(file, f => f.Name, f => f.Exists);
            ClientContext.ExecuteQueryRetry();
            ClientContext.Load(folder, f => f.Name, f => f.Exists);
            ClientContext.ExecuteQueryRetry();
            bool srcIsFolder = folder.Exists;

            if (Force || ShouldContinue(string.Format(Resources.CopyFile0To1, ServerRelativeUrl, TargetUrl), Resources.Confirm))
            {
                var srcWeb = ClientContext.Web;
                ClientContext.Load(srcWeb, s => s.Url);
                ClientContext.ExecuteQueryRetry();

                Uri uri = new Uri(ClientContext.Url);
                Uri targetUri = new Uri(uri, TargetUrl);
                var webUrl = Microsoft.SharePoint.Client.Web.WebUrlFromFolderUrlDirect(ClientContext, targetUri);
                var targetContext = ClientContext.Clone(webUrl.AbsoluteUri);
                var dstWeb = targetContext.Web;
                targetContext.Load(dstWeb, s => s.Url);
                targetContext.ExecuteQueryRetry();
                if (srcWeb.Url == dstWeb.Url)
                {
                    try
                    {
                        // If src/dst are on the same Web, then try using CopyTo - backwards compability
                        file.CopyTo(TargetUrl, OverwriteIfAlreadyExists);
                        ClientContext.ExecuteQueryRetry();
                        return;
                    }
                    catch
                    {
                        //swallow exception, in case target was a lib/folder
                    }
                }

                //different site/site collection
                Folder targetFolder = null;
                string fileOrFolderName = null;
                bool targetFolderExists = false;
                try
                {
                    targetFolder = targetContext.Web.GetFolderByServerRelativeUrl(TargetUrl);
                    targetContext.Load(targetFolder, f => f.Name, f => f.Exists);
                    targetContext.ExecuteQueryRetry();
                    if (!targetFolder.Exists) throw new Exception("TargetUrl is an existing file, not folder");
                    targetFolderExists = true;
                }
                catch (Exception)
                {
                    Expression<Func<List, object>> expressionRelativeUrl = l => l.RootFolder.ServerRelativeUrl;
                    var query = targetContext.Web.Lists.IncludeWithDefaultProperties(expressionRelativeUrl);
                    var lists = targetContext.LoadQuery(query);
                    targetContext.ExecuteQueryRetry();
                    lists = lists.OrderByDescending(l => l.RootFolder.ServerRelativeUrl); // order descending in case more lists start with the same
                    foreach (List targetList in lists)
                    {
                        if (!TargetUrl.StartsWith(targetList.RootFolder.ServerRelativeUrl, StringComparison.InvariantCultureIgnoreCase)) continue;
                        fileOrFolderName = Regex.Replace(TargetUrl, targetList.RootFolder.ServerRelativeUrl, "", RegexOptions.IgnoreCase).Trim('/');
                        targetFolder = srcIsFolder ? targetList.RootFolder.EnsureFolder(fileOrFolderName) : targetList.RootFolder;
                        break;
                    }
                }
                if (targetFolder == null) throw new Exception("Target does not exist");
                if (srcIsFolder)
                {
                    if (!SkipSourceFolderName && targetFolderExists)
                    {
                        targetFolder = targetFolder.EnsureFolder(folder.Name);
                    }
                    CopyFolder(folder, targetFolder);
                }
                else
                {
                    UploadFile(file, targetFolder, fileOrFolderName);
                }
            }
        }

        private void CopyFolder(Folder sourceFolder, Folder targetFolder)
        {
            ClientContext.Load(sourceFolder, folder => folder.Files, folder => folder.Folders, folder => folder.Files.Include(f => f.ServerRelativeUrl));
            sourceFolder.EnsureProperty(f => f.ServerRelativeUrl);
            ClientContext.ExecuteQueryRetry();
            targetFolder.EnsureProperty(f => f.ServerRelativeUrl);
            targetFolder.Context.ExecuteQueryRetry();

            _progressFolder.RecordType = ProgressRecordType.Processing;
            _progressFolder.StatusDescription = $"{sourceFolder.ServerRelativeUrl} to {targetFolder.ServerRelativeUrl}";
            _progressFolder.PercentComplete = 0;
            WriteProgress(_progressFolder);


            _progressFile.RecordType = ProgressRecordType.Processing;
            foreach (File file in sourceFolder.Files)
            {
                _progressFile.StatusDescription = $"{file.ServerRelativeUrl}";
                _progressFile.PercentComplete = 0;
                WriteProgress(_progressFile);
                UploadFile(file, targetFolder);
                _progressFile.PercentComplete = 100;
                WriteProgress(_progressFile);
            }
            _progressFile.RecordType = ProgressRecordType.Completed;
            WriteProgress(_progressFile);

            _progressFolder.RecordType = ProgressRecordType.Processing;
            _progressFolder.PercentComplete = 100;
            WriteProgress(_progressFolder);

            foreach (Folder folder in sourceFolder.Folders)
            {
                var childFolder = targetFolder.EnsureFolder(folder.Name);
                CopyFolder(folder, childFolder);
            }
        }

        private void UploadFile(File srcFile, Folder targetFolder, string filename = "")
        {
            var binaryStream = srcFile.OpenBinaryStream();
            ClientContext.ExecuteQueryRetry();
            if (string.IsNullOrWhiteSpace(filename)) filename = srcFile.Name;
            targetFolder.UploadFile(filename, binaryStream.Value, OverwriteIfAlreadyExists);
            targetFolder.Context.ExecuteQueryRetry();
        }
    }
}
