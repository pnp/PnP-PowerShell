using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Events
{

    [TestClass]
    public class AddEventReceiverTests
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
        public void AddPnPEventReceiverTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Add-PnPEventReceiver",new CommandParameter("List", "null"),new CommandParameter("Name", "null"),new CommandParameter("Url", "null"),new CommandParameter("EventReceiverType", "null"),new CommandParameter("Synchronization", "null"),new CommandParameter("SequenceNumber", "null"),new CommandParameter("Force", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            