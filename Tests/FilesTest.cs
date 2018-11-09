#if !ONPREMISES
using Microsoft.Online.SharePoint.TenantAdministration;
using Microsoft.SharePoint.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests
{
    [TestClass]
    public class FilesTests
    {
        private string site1Id;
        private string site2Id;
        private string site1Url;
        private string site2Url;

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
            using (var ctx = TestCommon.CreateClientContext())
            {
                site1Id = Guid.NewGuid().ToString();
                site2Id = Guid.NewGuid().ToString();

                site1Url = $"{TestCommon.GetTenantRootUrl(ctx)}/sites/PNPPS_Test_{site1Id}";
                site2Url = $"{TestCommon.GetTenantRootUrl(ctx)}/sites/PNPPS_Test_{site2Id}";

                using (var site1Ctx = OfficeDevPnP.Core.Sites.SiteCollection.CreateAsync(ctx, new OfficeDevPnP.Core.Sites.CommunicationSiteCollectionCreationInformation()
                {
                    Url = site1Url,
                    Lcid = 1033,
                    Title = "PnP PowerShell File Copy Test Site 1"
                }).GetAwaiter().GetResult())
                {
                    site1Ctx.Web.EnsureProperty(w => w.ServerRelativeUrl);
                    Folder folder = site1Ctx.Web.GetFolderByServerRelativeUrl($"{site1Ctx.Web.ServerRelativeUrl}/Shared%20Documents");
                    FileCreationInformation fci = new FileCreationInformation
                    {
                        Content = System.Text.Encoding.ASCII.GetBytes(targetFileContents),
                        Url = targetFileName,
                        Overwrite = true
                    };
                    File fileToUpload = folder.Files.Add(fci);
                    site1Ctx.Load(fileToUpload);
                    fci.Url = targetFileNameWithAmpersand;
                    fci.Overwrite = true;
                    fileToUpload = folder.Files.Add(fci);
                    site1Ctx.Load(fileToUpload);
                    site1Ctx.ExecuteQueryRetry();

                    folder.EnsureFolder(targetCopyFolderName);

                }
                OfficeDevPnP.Core.Sites.SiteCollection.CreateAsync(ctx, new OfficeDevPnP.Core.Sites.CommunicationSiteCollectionCreationInformation()
                {
                    Url = site2Url,
                    Lcid = 1033,
                    Title = "PnP PowerShell File Copy Test Site 2"
                }).GetAwaiter().GetResult();
            }
        }


        [TestCleanup]
        public void Cleanup()
        {

            using (var ctx = TestCommon.CreateTenantClientContext())
            {
                Tenant tenant = new Tenant(ctx);
                tenant.DeleteSiteCollection(site1Url, false);
                tenant.DeleteSiteCollection(site2Url, false);
            }
        }

        [TestMethod]
        public void GetFile_AsListItem_Test()
        {
            using (var scope = new PSTestScope(site1Url, true))
            {
                var siteRelativeFolderUrl = $"/sites/PNPPS_Test_{site1Id}/Shared%20Documents";

                var values = new Hashtable();
                values.Add("Title", "Test");
                //Get-PnPFile -Url /sites/project/_catalogs/themes/15/company.spcolor -AsFile",
                var results = scope.ExecuteCommand("Get-PnPFile",
                    new CommandParameter("Url", $"{siteRelativeFolderUrl}/{targetFileName}"),
                    new CommandParameter("AsListItem"));

                Assert.IsTrue(results.Any());

                Assert.IsTrue(results[0].BaseObject.GetType() == typeof(Microsoft.SharePoint.Client.ListItem));
            }
        }

        [TestMethod]
        public void GetFile_AsFile_Test()
        {
            using (var scope = new PSTestScope(site1Url, true))
            {
                var siteRelativeFolderUrl = $"/sites/PNPPS_Test_{site1Id}/Shared%20Documents";

                var results = scope.ExecuteCommand("Get-PnPFile",
                    new CommandParameter("Url", $"{siteRelativeFolderUrl}/{targetFileName}"),
                    new CommandParameter("AsFile"));

                Assert.IsTrue(results.Any());

                Assert.IsTrue(results[0].BaseObject.GetType() == typeof(Microsoft.SharePoint.Client.File));
            }
        }

        [TestMethod]
        public void CopyFileTest()
        {
            using (var scope = new PSTestScope(site1Url, true))
            {
                var sourceUrl = $"/sites/PNPPS_Test_{site1Id}/Shared%20Documents/{targetFileName}";

                var destinationUrl = $"/sites/PNPPS_Test_{site1Id}/Shared%20Documents/{targetCopyFolderName}";

                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationUrl),
                    new CommandParameter("Force"));


                using (var ctx = TestCommon.CreateClientContext(site1Url))
                {
                    File initialFile = ctx.Web.GetFileByServerRelativeUrl(destinationUrl);
                    ctx.Load(initialFile);
                    ctx.ExecuteQueryRetry();
                    if (!initialFile.Exists)
                    {
                        Assert.Fail("Copied file cannot be found");
                    }
                }
            }
        }

        [TestMethod]
        public void CopyFile_WithAmpersand_Test()
        {
            using (var scope = new PSTestScope(site1Url, true))
            {
                var sourceUrl = $"/sites/PNPPS_Test_{site1Id}/Shared%20Documents/{targetFileNameWithAmpersand}";
                var destinationUrl = $"/sites/PNPPS_Test_{site1Id}/Shared%20Documents/{targetCopyFolderName}";

                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContext(site1Url))
                {
                    File initialFile = ctx.Web.GetFileByServerRelativeUrl(destinationUrl);
                    ctx.Load(initialFile);
                    ctx.ExecuteQueryRetry();
                    if (!initialFile.Exists)
                    {
                        Assert.Fail("Copied file cannot be found");
                    }
                }
            }
        }

        [TestMethod]
        public void CopyFile_BetweenSiteCollections_Test()
        {
            using (var scope = new PSTestScope(site1Url, true))
            {
                var sourceUrl = $"/sites/PNPPS_Test_{site1Id}/Shared%20Documents/{targetFileName}";
                var destinationFolderUrl = $"/sites/PNPPS_Test_{site2Id}/Shared%20Documents";
                string destinationFileUrl = $"/sites/PNPPS_Test_{site2Id}/Shared%20Documents/{targetFileName}";
                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationFolderUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContext(site2Url))
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
            using (var scope = new PSTestScope(site1Url, true))
            {
                var sourceUrl = $"/sites/PNPPS_Test_{site1Id}/Shared%20Documents/{targetFileNameWithAmpersand}";
                var destinationFolderUrl = $"/sites/PNPPS_Test_{site2Id}/Shared%20Documents";
                string destinationFileUrl = $"/sites/PNPPS_Test_{site2Id}/Shared%20Documents/{targetFileNameWithAmpersand}";
                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationFolderUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContext(site2Url))
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
#endif