using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Lists
{

    [TestClass]
    public class AddViewTests
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
        public void AddPnPViewTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Add-PnPView",new CommandParameter("List", "null"),new CommandParameter("Title", "null"),new CommandParameter("Query", "null"),new CommandParameter("Fields", "null"),new CommandParameter("ViewType", "null"),new CommandParameter("RowLimit", "null"),new CommandParameter("Personal", "null"),new CommandParameter("SetAsDefault", "null"),new CommandParameter("Paged", "null"),new CommandParameter("Aggregations", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            