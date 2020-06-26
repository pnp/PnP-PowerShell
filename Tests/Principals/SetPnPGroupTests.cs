using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Principals
{

    [TestClass]
    public class SetGroupTests
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
        public void SetPnPGroupTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPGroup",new CommandParameter("Identity", "null"),new CommandParameter("SetAssociatedGroup", "null"),new CommandParameter("AddRole", "null"),new CommandParameter("RemoveRole", "null"),new CommandParameter("Title", "null"),new CommandParameter("Owner", "null"),new CommandParameter("Description", "null"),new CommandParameter("AllowRequestToJoinLeave", "null"),new CommandParameter("AutoAcceptRequestToJoinLeave", "null"),new CommandParameter("AllowMembersEditMembership", "null"),new CommandParameter("OnlyAllowMembersViewMembership", "null"),new CommandParameter("RequestToJoinEmail", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            