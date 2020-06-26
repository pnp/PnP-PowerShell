using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Workflows
{

    [TestClass]
    public class AddWorkflowSubscriptionTests
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
        public void AddPnPWorkflowSubscriptionTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Add-PnPWorkflowSubscription",new CommandParameter("Name", "null"),new CommandParameter("DefinitionName", "null"),new CommandParameter("List", "null"),new CommandParameter("StartManually", "null"),new CommandParameter("StartOnCreated", "null"),new CommandParameter("StartOnChanged", "null"),new CommandParameter("HistoryListName", "null"),new CommandParameter("TaskListName", "null"),new CommandParameter("AssociationValues", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            