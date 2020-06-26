using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.ClientSidePages
{

    [TestClass]
    public class SetClientSidePageTests
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
        public void SetPnPClientSidePageTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPClientSidePage",new CommandParameter("Identity", "null"),new CommandParameter("Name", "null"),new CommandParameter("Title", "null"),new CommandParameter("LayoutType", "null"),new CommandParameter("PromoteAs", "null"),new CommandParameter("CommentsEnabled", "null"),new CommandParameter("Publish", "null"),new CommandParameter("HeaderType", "null"),new CommandParameter("ContentType", "null"),new CommandParameter("ThumbnailUrl", "null"),new CommandParameter("PublishMessage", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            