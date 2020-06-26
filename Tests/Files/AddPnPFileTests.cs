using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Files
{

    [TestClass]
    public class AddFileTests
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
        public void AddPnPFileTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Add-PnPFile",new CommandParameter("Path", "null"),new CommandParameter("Folder", "null"),new CommandParameter("FileName", "null"),new CommandParameter("NewFileName", "null"),new CommandParameter("Stream", "null"),new CommandParameter("Checkout", "null"),new CommandParameter("CheckInComment", "null"),new CommandParameter("Approve", "null"),new CommandParameter("ApproveComment", "null"),new CommandParameter("Publish", "null"),new CommandParameter("PublishComment", "null"),new CommandParameter("UseWebDav", "null"),new CommandParameter("Values", "null"),new CommandParameter("ContentType", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            