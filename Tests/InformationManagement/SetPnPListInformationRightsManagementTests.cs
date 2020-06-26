using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.InformationManagement
{

    [TestClass]
    public class SetListInformationRightsManagementTests
    {
        #region Test Setup/CleanUp

        [TestInitialize]
        public void Initialize()
        {
            using (var scope = new PSTestScope())
            {
                // Example
                // scope.ExecuteCommand("cmdlet", new CommandParameter("param1", prop));
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var scope = new PSTestScope())
            {
                try
                {

                }
                catch (Exception)
                {
                    // Describe Exception
                }
            }
        }

        #endregion

        #region Scaffolded Cmdlet Tests

        

        //TODO: This is a scaffold of the cmdlet - complete the unit test
        //[TestMethod]
        public void SetPnPListInformationRightsManagementTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPListInformationRightsManagement",new CommandParameter("List", "null"),new CommandParameter("Enable", "null"),new CommandParameter("EnableExpiration", "null"),new CommandParameter("EnableRejection", "null"),new CommandParameter("AllowPrint", "null"),new CommandParameter("AllowScript", "null"),new CommandParameter("AllowWriteCopy", "null"),new CommandParameter("DisableDocumentBrowserView", "null"),new CommandParameter("DocumentAccessExpireDays", "null"),new CommandParameter("DocumentLibraryProtectionExpireDate", "null"),new CommandParameter("EnableDocumentAccessExpire", "null"),new CommandParameter("EnableDocumentBrowserPublishingView", "null"),new CommandParameter("EnableGroupProtection", "null"),new CommandParameter("EnableLicenseCacheExpire", "null"),new CommandParameter("LicenseCacheExpireDays", "null"),new CommandParameter("GroupName", "null"),new CommandParameter("PolicyDescription", "null"),new CommandParameter("PolicyTitle", "null"),new CommandParameter("TemplateId", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            