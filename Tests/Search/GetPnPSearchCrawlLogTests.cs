using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Search
{

    [TestClass]
    public class GetSearchCrawlLogTests
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
        public void GetPnPSearchCrawlLogTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Get-PnPSearchCrawlLog",new CommandParameter("LogLevel", "null"),new CommandParameter("RowLimit", "null"),new CommandParameter("Filter", "null"),new CommandParameter("ContentSource", "null"),new CommandParameter("StartDate", "null"),new CommandParameter("EndDate", "null"),new CommandParameter("RawFormat", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            