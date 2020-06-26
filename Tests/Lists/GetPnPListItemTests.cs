using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Lists
{

    [TestClass]
    public class GetListItemTests
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
        public void GetPnPListItemTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Get-PnPListItem",new CommandParameter("List", "null"),new CommandParameter("Id", "null"),new CommandParameter("UniqueId", "null"),new CommandParameter("Query", "null"),new CommandParameter("FolderServerRelativeUrl", "null"),new CommandParameter("Fields", "null"),new CommandParameter("PageSize", "null"),new CommandParameter("ScriptBlock", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            