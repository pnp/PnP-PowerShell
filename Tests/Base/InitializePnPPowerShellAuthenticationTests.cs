using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Base
{

    [TestClass]
    public class InitializePowerShellAuthenticationTests
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
        public void InitializePnPPowerShellAuthenticationTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Initialize-PnPPowerShellAuthentication",new CommandParameter("ApplicationName", "null"),new CommandParameter("Tenant", "null"),new CommandParameter("CertificatePath", "null"),new CommandParameter("CommonName", "null"),new CommandParameter("Country", "null"),new CommandParameter("State", "null"),new CommandParameter("Locality", "null"),new CommandParameter("Organization", "null"),new CommandParameter("OrganizationUnit", "null"),new CommandParameter("ValidYears", "null"),new CommandParameter("CertificatePassword", "null"),new CommandParameter("OutPath", "null"),new CommandParameter("Store", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            