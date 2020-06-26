using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Files
{

    [TestClass]
    public class RenameFileTests
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
        public void RenamePnPFileTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Rename-PnPFile",new CommandParameter("ServerRelativeUrl", "null"),new CommandParameter("SiteRelativeUrl", "null"),new CommandParameter("TargetFileName", "null"),new CommandParameter("OverwriteIfAlreadyExists", "null"),new CommandParameter("Force", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            