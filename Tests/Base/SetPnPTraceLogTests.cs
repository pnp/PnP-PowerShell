using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Base
{

    [TestClass]
    public class SetTraceLogTests
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
        public void SetPnPTraceLogTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Set-PnPTraceLog",new CommandParameter("On", "null"),new CommandParameter("LogFile", "null"),new CommandParameter("WriteToConsole", "null"),new CommandParameter("Level", "null"),new CommandParameter("Delimiter", "null"),new CommandParameter("IndentSize", "null"),new CommandParameter("AutoFlush", "null"),new CommandParameter("Off", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            