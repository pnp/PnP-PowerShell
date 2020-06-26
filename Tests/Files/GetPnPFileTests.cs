using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Files
{

    [TestClass]
    public class GetFileTests
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
        public void GetPnPFileTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Get-PnPFile",new CommandParameter("Url", "null"),new CommandParameter("Path", "null"),new CommandParameter("Filename", "null"),new CommandParameter("AsFile", "null"),new CommandParameter("AsListItem", "null"),new CommandParameter("ThrowExceptionIfFileNotFound", "null"),new CommandParameter("AsString", "null"),new CommandParameter("Force", "null"),new CommandParameter("AsFileObject", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            