using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Utilities
{

    [TestClass]
    public class SendMailTests
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
        public void SendPnPMailTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Send-PnPMail",new CommandParameter("Server", "null"),new CommandParameter("From", "null"),new CommandParameter("Password", "null"),new CommandParameter("To", "null"),new CommandParameter("Cc", "null"),new CommandParameter("Subject", "null"),new CommandParameter("Body", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            