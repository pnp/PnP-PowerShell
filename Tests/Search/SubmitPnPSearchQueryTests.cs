using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Search
{

    [TestClass]
    public class SubmitSearchQueryTests
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
        public void SubmitPnPSearchQueryTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Submit-PnPSearchQuery",new CommandParameter("Query", "null"),new CommandParameter("StartRow", "null"),new CommandParameter("MaxResults", "null"),new CommandParameter("All", "null"),new CommandParameter("TrimDuplicates", "null"),new CommandParameter("Properties", "null"),new CommandParameter("Refiners", "null"),new CommandParameter("Culture", "null"),new CommandParameter("QueryTemplate", "null"),new CommandParameter("SelectProperties", "null"),new CommandParameter("RefinementFilters", "null"),new CommandParameter("SortList", "null"),new CommandParameter("RankingModelId", "null"),new CommandParameter("ClientType", "null"),new CommandParameter("CollapseSpecification", "null"),new CommandParameter("HiddenConstraints", "null"),new CommandParameter("TimeZoneId", "null"),new CommandParameter("EnablePhonetic", "null"),new CommandParameter("EnableStemming", "null"),new CommandParameter("EnableQueryRules", "null"),new CommandParameter("SourceId", "null"),new CommandParameter("ProcessBestBets", "null"),new CommandParameter("ProcessPersonalFavorites", "null"),new CommandParameter("RelevantResults", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            