using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SharePoint.Client;
using System.Management.Automation.Runspaces;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace SharePointPnP.PowerShell.Tests
{
    [TestClass]
    public class FilesTests
    {
        private const string targetLibraryRelativeUrl = "/sites/dev/Shared%20Documents";
        private const string targetLibraryName = "Documents";
        private const string targetLibraryDesc = "Documents library for Files testing";
        private const string targetFileName = "Testfile.txt";
        private const string targetFileContents = "Some random file contents";
        private const string targetCopyFolderName = "CopyDestination";
        private const string targetFileNameWithAmpersand = "Test & file.txt";
        private const string targetSite2LibraryRelativeUrl = "/sites/dev2/Shared%20Documents";

        [TestInitialize]
        public void Initialize()
        {
            //With thanks to Paolo Pialorsi https://piasys.com/blog/uploading-a-file-into-a-library-via-csom-even-if-the-library-does-not-exist/
            using (var ctx = TestCommon.CreateClientContext())
            {
                ExceptionHandlingScope scope = new ExceptionHandlingScope(ctx);
                using (scope.StartScope())
                {
                    using (scope.StartTry())
                    {
                        Folder folder = ctx.Web.GetFolderByServerRelativeUrl(targetLibraryRelativeUrl);
                    }
                    using (scope.StartCatch())
                    {
                        // Create the library, in case it doesn’t exist
                        ListCreationInformation lci = new ListCreationInformation();
                        lci.Title = targetLibraryName;
                        lci.Description = targetLibraryDesc;
                        lci.TemplateType = (Int32)ListTemplateType.DocumentLibrary;
                        lci.QuickLaunchOption = QuickLaunchOptions.On;
                        List library = ctx.Web.Lists.Add(lci);
                    }
                    using (scope.StartFinally())
                    {
                        Folder folder = ctx.Web.GetFolderByServerRelativeUrl(targetLibraryRelativeUrl);
                        FileCreationInformation fci = new FileCreationInformation();
                        fci.Content = Encoding.ASCII.GetBytes(targetFileContents);
                        fci.Url = targetFileName;
                        fci.Overwrite = true;
                        File fileToUpload = folder.Files.Add(fci);
                        ctx.Load(fileToUpload);

                        fci.Url = targetFileNameWithAmpersand;
                        fci.Overwrite = true;
                        fileToUpload = folder.Files.Add(fci);
                        ctx.Load(fileToUpload);

                        folder.Folders.Add(targetCopyFolderName);
                    }
                }
                ctx.ExecuteQuery();
            }
        }
        

        [TestCleanup]
        public void Cleanup()
        {
            using (var ctx = TestCommon.CreateClientContext())
            {
                ExceptionHandlingScope scope = new ExceptionHandlingScope(ctx);
                using (scope.StartScope())
                {
                    using (scope.StartTry())
                    {
                        File initialFile = ctx.Web.GetFileByServerRelativeUrl(targetLibraryRelativeUrl + "/" + targetFileName);
                        if (initialFile != null)
                        {
                            initialFile.DeleteObject();
                        }
                        Folder copyFolder = ctx.Web.GetFolderByServerRelativeUrl(targetLibraryRelativeUrl + "/" + targetCopyFolderName);
                        if (copyFolder != null)
                        {
                            copyFolder.DeleteObject();
                        }
                    }
                    using (scope.StartCatch())
                    {
                        // Ignore as file not created or already deleted
                    }
                }
                ctx.ExecuteQuery();
            }

            using (var ctx = TestCommon.CreateClientContextDev2())
            {
                ExceptionHandlingScope scope = new ExceptionHandlingScope(ctx);
                using (scope.StartScope())
                {
                    using (scope.StartTry())
                    {
                        File initialFile = ctx.Web.GetFileByServerRelativeUrl(targetSite2LibraryRelativeUrl + "/" + targetFileName);
                        if (initialFile != null)
                        {
                            initialFile.DeleteObject();
                        }
                        File ampersandFile = ctx.Web.GetFileByServerRelativeUrl(targetSite2LibraryRelativeUrl + "/" + targetFileNameWithAmpersand);
                        if (ampersandFile != null)
                        {
                            ampersandFile.DeleteObject();
                        }
                    }
                    using (scope.StartCatch())
                    {
                        // Ignore as file not created or already deleted
                    }
                }
                ctx.ExecuteQuery();
            }
        }

        [TestMethod]
        public void GetFile_AsListItem_Test()
        {
            using (var scope = new PSTestScope(true))
            {
                var values = new Hashtable();
                values.Add("Title", "Test");
                //Get-PnPFile -Url /sites/project/_catalogs/themes/15/company.spcolor -AsFile",
                var results = scope.ExecuteCommand("Get-PnPFile",
                    new CommandParameter("Url", System.IO.Path.Combine(targetLibraryRelativeUrl,targetFileName)),
                    new CommandParameter("AsListItem"));

                Assert.IsTrue(results.Any());

                Assert.IsTrue(results[0].BaseObject.GetType() == typeof(Microsoft.SharePoint.Client.ListItem));
            }
        }

        [TestMethod]
        public void GetFile_AsFile_Test()
        {
            using (var scope = new PSTestScope(true))
            {
                var results = scope.ExecuteCommand("Get-PnPFile",
                    new CommandParameter("Url", System.IO.Path.Combine(targetLibraryRelativeUrl, targetFileName)),
                    new CommandParameter("AsFile"));

                Assert.IsTrue(results.Any());

                Assert.IsTrue(results[0].BaseObject.GetType() == typeof(Microsoft.SharePoint.Client.File));
            }
        }

        [TestMethod]
        public void CopyFileTest()
        {
            using (var scope = new PSTestScope(true))
            {
                string sourceUrl = targetLibraryRelativeUrl + "/" + targetFileName;
                string destinationUrl = targetLibraryRelativeUrl + "/" + targetCopyFolderName + "/" + targetFileName;
                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContext())
                {
                    File initialFile = ctx.Web.GetFileByServerRelativeUrl(destinationUrl);
                    if (initialFile == null)
                    {
                        Assert.Fail("Copied file cannot be found");
                    }
                }
            }
        }

        [TestMethod]
        public void CopyFile_WithAmpersand_Test()
        {
            using (var scope = new PSTestScope(true))
            {
                string sourceUrl = targetLibraryRelativeUrl + "/" + targetFileNameWithAmpersand;
                string destinationUrl = targetLibraryRelativeUrl + "/" + targetCopyFolderName + "/" + targetFileNameWithAmpersand;
                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContext())
                {
                    File initialFile = ctx.Web.GetFileByServerRelativeUrl(destinationUrl);
                    if (initialFile == null)
                    {
                        Assert.Fail("Copied file cannot be found");
                    }
                }
            }
        }

        [TestMethod]
        public void CopyFile_BetweenSiteCollections_Test()
        {
            using (var scope = new PSTestScope(true))
            {
                string sourceUrl = targetLibraryRelativeUrl + "/" + targetFileName;
                string destinationFolderUrl = targetSite2LibraryRelativeUrl;
                string destinationFileUrl = targetSite2LibraryRelativeUrl + "/" + targetFileName;
                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationFolderUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContextDev2())
                {
                    File initialFile = ctx.Web.GetFileByServerRelativeUrl(destinationFileUrl);
                    ctx.Load(initialFile);
                    ctx.ExecuteQuery();
                    if (!initialFile.Exists)
                    {
                        Assert.Fail("Copied file cannot be found");
                    }
                }
            }
        }

        [TestMethod]
        public void CopyFile_BetweenSiteCollectionsWithAmpersand_Test()
        {
            using (var scope = new PSTestScope(true))
            {
                string sourceUrl = targetLibraryRelativeUrl + "/" + targetFileNameWithAmpersand;
                string destinationFolderUrl = targetSite2LibraryRelativeUrl;
                string destinationFileUrl = targetSite2LibraryRelativeUrl + "/" + targetFileNameWithAmpersand;
                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationFolderUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContextDev2())
                {
                    File initialFile = ctx.Web.GetFileByServerRelativeUrl(destinationFileUrl);
                    ctx.Load(initialFile);
                    ctx.ExecuteQuery();
                    if (!initialFile.Exists)
                    {
                        Assert.Fail("Copied file cannot be found");
                    }
                }
            }
        }
    }
}
