using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Site
{

    [TestClass]
    public class SetSiteTests
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
        public void SetPnPSiteTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPSite",new CommandParameter("Identity", "null"),new CommandParameter("Classification", "null"),new CommandParameter("DisableFlows", "null"),new CommandParameter("LogoFilePath", "null"),new CommandParameter("Sharing", "null"),new CommandParameter("StorageMaximumLevel", "null"),new CommandParameter("StorageWarningLevel", "null"),new CommandParameter("UserCodeMaximumLevel", "null"),new CommandParameter("UserCodeWarningLevel", "null"),new CommandParameter("LockState", "null"),new CommandParameter("AllowSelfServiceUpgrade", "null"),new CommandParameter("NoScriptSite", "null"),new CommandParameter("Owners", "null"),new CommandParameter("CommentsOnSitePagesDisabled", "null"),new CommandParameter("DefaultLinkPermission", "null"),new CommandParameter("DefaultSharingLinkType", "null"),new CommandParameter("DisableAppViews", "null"),new CommandParameter("DisableCompanyWideSharingLinks", "null"),new CommandParameter("DisableSharingForNonOwners", "null"),new CommandParameter("LocaleId", "null"),new CommandParameter("NewUrl", "null"),new CommandParameter("RestrictedToGeo", "null"),new CommandParameter("SocialBarOnSitePagesDisabled", "null"),new CommandParameter("Wait", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            