using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Management.Automation.Runspaces;

namespace SharePointPnP.PowerShell.Tests.Base
{

    [TestClass]
    public class ConnectOnlineTests
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
        public void ConnectPnPOnlineTest()
        {
                                
            using (var scope = new PSTestScope(true))
            {
                // Complete writing cmd parameters
                var results = scope.ExecuteCommand("Connect-PnPOnline",new CommandParameter("ReturnConnection", "null"),new CommandParameter("Url", "null"),new CommandParameter("Credentials", "null"),new CommandParameter("CurrentCredentials", "null"),new CommandParameter("UseAdfs", "null"),new CommandParameter("UseAdfsCert", "null"),new CommandParameter("ClientCertificate", "null"),new CommandParameter("Kerberos", "null"),new CommandParameter("LoginProviderName", "null"),new CommandParameter("MinimalHealthScore", "null"),new CommandParameter("RetryCount", "null"),new CommandParameter("RetryWait", "null"),new CommandParameter("RequestTimeout", "null"),new CommandParameter("Realm", "null"),new CommandParameter("AppId", "null"),new CommandParameter("AppSecret", "null"),new CommandParameter("ClientSecret", "null"),new CommandParameter("UseWebLogin", "null"),new CommandParameter("AuthenticationMode", "null"),new CommandParameter("CreateDrive", "null"),new CommandParameter("DriveName", "null"),new CommandParameter("SPOManagementShell", "null"),new CommandParameter("PnPO365ManagementShell", "null"),new CommandParameter("LaunchBrowser", "null"),new CommandParameter("Graph", "null"),new CommandParameter("ClientId", "null"),new CommandParameter("RedirectUri", "null"),new CommandParameter("Tenant", "null"),new CommandParameter("CertificatePath", "null"),new CommandParameter("CertificateBase64Encoded", "null"),new CommandParameter("Certificate", "null"),new CommandParameter("CertificatePassword", "null"),new CommandParameter("PEMCertificate", "null"),new CommandParameter("PEMPrivateKey", "null"),new CommandParameter("Thumbprint", "null"),new CommandParameter("ClearTokenCache", "null"),new CommandParameter("AzureEnvironment", "null"),new CommandParameter("Scopes", "null"),new CommandParameter("AADDomain", "null"),new CommandParameter("AccessToken", "null"),new CommandParameter("TenantAdminUrl", "null"),new CommandParameter("SkipTenantAdminCheck", "null"),new CommandParameter("IgnoreSslErrors", "null"),new CommandParameter("NoTelemetry", "null"));
                Assert.IsNotNull(results);
            }

        }
            

        #endregion
    }
}
            