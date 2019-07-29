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
        private string _site1Id;
        private string _site2Id;
        private string _site1Url;
        private string _site2Url;
        private string _site1RelativeUrl;
        private string _site2RelativeUrl;


        private string Site1RelativeFolderUrl
        {
            get
            {
#if ONPREMISES
                return $"{_site1RelativeUrl}/Shared%20Documents";
#else
                return $"{_site1RelativeUrl}/Shared Documents";
#endif
            }
        }

        private string Site2RelativeFolderUrl
        {
            get
            {
#if ONPREMISES
                return $"{_site2RelativeUrl}/Shared%20Documents";
#else
                return $"{_site2RelativeUrl}/Shared Documents";
#endif
            }
        }

        private const string TargetFileName = "Testfile.txt";
        private const string TargetFileContents = "Some random file contents";
        private const string TargetCopyFolderName = "CopyDestination";
        private const string TargetFileNameWithAmpersand = "Test & file.txt";

        [TestInitialize]
        public void Initialize()
        {
            using (var ctx = TestCommon.CreateClientContext())
            {
                _site1Id = Guid.NewGuid().ToString();
                _site2Id = Guid.NewGuid().ToString();

                _site1RelativeUrl = $"/sites/PNPPS_Test_{_site1Id}";
                _site2RelativeUrl = $"/sites/PNPPS_Test_{_site2Id}";

                _site1Url = $"{TestCommon.GetTenantRootUrl(ctx)}{_site1RelativeUrl}";
                _site2Url = $"{TestCommon.GetTenantRootUrl(ctx)}{_site2RelativeUrl}";


                using (var site1Ctx = OfficeDevPnP.Core.Sites.SiteCollection.CreateAsync(ctx, new OfficeDevPnP.Core.Sites.CommunicationSiteCollectionCreationInformation()
                {
                    Url = _site1Url,
                    Lcid = 1033,
                    Title = "PnP PowerShell File Copy Test Site 1"
                }).GetAwaiter().GetResult())
                {
                    Folder folder = site1Ctx.Web.GetFolderByServerRelativeUrl(Site1RelativeFolderUrl);

                    FileCreationInformation fci = new FileCreationInformation
                    {
                        Content = System.Text.Encoding.ASCII.GetBytes(TargetFileContents),
                        Url = TargetFileName,
                        Overwrite = true
                    };
                    File fileToUpload = folder.Files.Add(fci);
                    site1Ctx.Load(fileToUpload);

                    fci.Url = TargetFileNameWithAmpersand;
                    fci.Overwrite = true;
                    fileToUpload = folder.Files.Add(fci);
                    site1Ctx.Load(fileToUpload);

                    site1Ctx.ExecuteQueryRetry();

                    folder.EnsureFolder(TargetCopyFolderName);

                }
                OfficeDevPnP.Core.Sites.SiteCollection.CreateAsync(ctx, new OfficeDevPnP.Core.Sites.CommunicationSiteCollectionCreationInformation()
                {
                    Url = _site2Url,
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
                tenant.DeleteSiteCollection(_site1Url, false);
                tenant.DeleteSiteCollection(_site2Url, false);
            }
        }

        [TestMethod]
        public void GetFile_AsListItem_Test()
        {
            using (var scope = new PSTestScope(_site1Url, true))
            {
                var siteRelativeFileUrl = $"{Site1RelativeFolderUrl}/{TargetFileName}";

                var values = new Hashtable();
                values.Add("Title", "Test");
                //Get-PnPFile -Url /sites/project/_catalogs/themes/15/company.spcolor -AsFile",
                var results = scope.ExecuteCommand("Get-PnPFile",
                    new CommandParameter("Url", siteRelativeFileUrl),
                    new CommandParameter("AsListItem"));

                Assert.IsTrue(results.Any());

                Assert.IsTrue(results[0].BaseObject.GetType() == typeof(Microsoft.SharePoint.Client.ListItem));
            }
        }

        [TestMethod]
        public void GetFile_AsFile_Test()
        {
            using (var scope = new PSTestScope(_site1Url, true))
            {
                var siteRelativeFileUrl = $"{Site1RelativeFolderUrl}/{TargetFileName}";

                var results = scope.ExecuteCommand("Get-PnPFile",
                    new CommandParameter("Url", siteRelativeFileUrl),
                    new CommandParameter("AsFile"));
                
                Assert.IsFalse(results.Any());
            }
        }

        [TestMethod]
        public void GetFile_AsObject_Test()
        {
            using (var scope = new PSTestScope(_site1Url, true))
            {
                var siteRelativeFileUrl = $"{Site1RelativeFolderUrl}/{TargetFileName}";

                var results = scope.ExecuteCommand("Get-PnPFile",
                    new CommandParameter("Url", siteRelativeFileUrl));
                
                Assert.IsTrue(results.Any());
                Assert.IsTrue(results[0].BaseObject.GetType() == typeof(Microsoft.SharePoint.Client.File));
            }
        }

        [TestMethod]
        public void GetFile_AsString_Test()
        {
            using (var scope = new PSTestScope(_site1Url, true))
            {
                var siteRelateFileUrl = $"{Site1RelativeFolderUrl}/{TargetFileName}";

                var results = scope.ExecuteCommand("Get-PnPFile",
                    new CommandParameter("Url", siteRelateFileUrl),
                    new CommandParameter("AsString"));

                Assert.IsTrue(results.Any());
                Assert.IsTrue(results[0].ToString() == "Some random file contents");
            }
        }

        [TestMethod]
        public void CopyFileTest()
        {
            using (var scope = new PSTestScope(_site1Url, true))
            {
                var sourceUrl = $"{Site1RelativeFolderUrl}/{TargetFileName}";
                var destinationUrl = $"{Site1RelativeFolderUrl}/{TargetCopyFolderName}";
                var destinationFileUrl = $"{destinationUrl}/{TargetFileName}";

                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationUrl),
                    new CommandParameter("Force"));


                using (var ctx = TestCommon.CreateClientContext(_site1Url))
                {
                    File initialFile = ctx.Web.GetFileByServerRelativeUrl(destinationFileUrl);
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
            using (var scope = new PSTestScope(_site1Url, true))
            {
                var sourceUrl = $"{Site1RelativeFolderUrl}/{TargetFileNameWithAmpersand}";
                var destinationUrl = $"{Site1RelativeFolderUrl}/{TargetCopyFolderName}";
                var destinationFileUrl = $"{destinationUrl}/{TargetFileNameWithAmpersand}";

                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContext(_site1Url))
                {
                    File initialFile = ctx.Web.GetFileByServerRelativeUrl(destinationFileUrl);
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
            using (var scope = new PSTestScope(_site1Url, true))
            {
                var sourceUrl = $"{Site1RelativeFolderUrl}/{TargetFileName}";
                var destinationFolderUrl = $"{Site2RelativeFolderUrl}";
                string destinationFileUrl = $"{destinationFolderUrl}/{TargetFileName}";

                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationFolderUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContext(_site2Url))
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
            using (var scope = new PSTestScope(_site1Url, true))
            {
                var sourceUrl = $"{Site1RelativeFolderUrl}/{TargetFileNameWithAmpersand}";
                var destinationFolderUrl = $"{Site2RelativeFolderUrl}";
                string destinationFileUrl = $"{destinationFolderUrl}/{TargetFileNameWithAmpersand}";

                var results = scope.ExecuteCommand("Copy-PnPFile",
                    new CommandParameter("SourceUrl", sourceUrl),
                    new CommandParameter("TargetUrl", destinationFolderUrl),
                    new CommandParameter("Force"));

                using (var ctx = TestCommon.CreateClientContext(_site2Url))
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