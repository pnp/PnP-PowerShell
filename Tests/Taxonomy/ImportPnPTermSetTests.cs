using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Taxonomy
{

    [TestClass]
    public class ImportTermSetTests
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
        public void ImportPnPTermSetTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Import-PnPTermSet",new CommandParameter("GroupName", "null"),new CommandParameter("Path", "null"),new CommandParameter("TermSetId", "null"),new CommandParameter("SynchronizeDeletions", "null"),new CommandParameter("IsOpen", "null"),new CommandParameter("Contact", "null"),new CommandParameter("Owner", "null"),new CommandParameter("TermStoreName", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            