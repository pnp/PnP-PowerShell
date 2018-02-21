using System.Management.Automation;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SharePointPnP.PowerShell.Commands.Utilities;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet("Generate", "PnPAdalCertificate")]
    [CmdletHelp("Generate an app-only ADAL certificate and manifest for use when using CSOM via an ADAL application",
        Category = CmdletHelpCategory.Base)]
    [CmdletExample(
        Code = @"PS:> Generate-PnPAdalCertificate",
        Remarks = @"This will put the current context in the $ctx variable.",
        SortOrder = 1)]
    public class GeneratePnPAdalCertificate : PSCmdlet
    {
        [Parameter(Mandatory = false, HelpMessage = "Common Name (e.g. server FQDN or YOUR name)", Position = 0)]
        public string CommonName = "pnp.contoso.com";

        [Parameter(Mandatory = false, HelpMessage = "Country Name (2 letter code) [NO]", Position = 1)]
        public string Country = "NO";

        [Parameter(Mandatory = false, HelpMessage = "State or Province Name (full name)", Position = 2)]
        public string State = string.Empty;

        [Parameter(Mandatory = false, HelpMessage = "Locality Name (eg, city)", Position = 3)]
        public string Locality = string.Empty;

        [Parameter(Mandatory = false, HelpMessage = "Organization Name (eg, company) [PnP]", Position = 4)]
        public string Organization = "PnP";

        [Parameter(Mandatory = false, HelpMessage = "Organizational Unit Name (eg, section)", Position = 5)]
        public string OrganizationUnit = "PnPPosh";

        [Parameter(Mandatory = false, HelpMessage = "Number of years until expiration (default is 10, max is 30)", Position = 6)]
        public int ValidYears = 10;

        protected override void ProcessRecord()
        {
            List<string> x500values = new List<string>();
            if (!string.IsNullOrWhiteSpace(CommonName)) x500values.Add($"CN={CommonName}");
            if (!string.IsNullOrWhiteSpace(Country)) x500values.Add($"C={Country}");
            if (!string.IsNullOrWhiteSpace(State)) x500values.Add($"S={State}");
            if (!string.IsNullOrWhiteSpace(Locality)) x500values.Add($"L={Locality}");
            if (!string.IsNullOrWhiteSpace(Organization)) x500values.Add($"O={Organization}");
            if (!string.IsNullOrWhiteSpace(OrganizationUnit)) x500values.Add($"OU={OrganizationUnit}");

            string x500 = string.Join("; ", x500values);
            byte[] certificateBytes = CertificateHelper.CreateSelfSignCertificatePfx(x500, DateTime.Now, DateTime.Today.AddYears(ValidYears));
            var certificate = new X509Certificate2(certificateBytes, (SecureString)null, X509KeyStorageFlags.Exportable);


            var rawCert = certificate.GetRawCertData();
            var base64Cert = Convert.ToBase64String(rawCert);
            var rawCertHash = certificate.GetCertHash();
            var base64CertHash = Convert.ToBase64String(rawCertHash);
            var keyId = Guid.NewGuid();

            var template = @"
""keyCredentials"": [
    {{
        ""customKeyIdentifier"": ""{0}"",
        ""keyId"": ""{1}"",
        ""type"": ""AsymmetricX509Cert"",
        ""usage"": ""Verify"",
        ""value"":  ""{2}""
    }}
]";
            var manifestEntry = string.Format(template, base64CertHash, keyId, base64Cert);

            StringBuilder certificateBuilder = new StringBuilder();
            certificateBuilder.AppendLine("-----BEGIN CERTIFICATE-----");
            certificateBuilder.AppendLine(CertificateHelper.CertificateToBase64(certificate));
            certificateBuilder.AppendLine("-----END CERTIFICATE-----");

            StringBuilder privateKeyBuilder = new StringBuilder();
            privateKeyBuilder.AppendLine("-----BEGIN RSA PRIVATE KEY-----");
            privateKeyBuilder.AppendLine(CertificateHelper.PrivateKeyToBase64(certificate));
            privateKeyBuilder.AppendLine("-----END RSA PRIVATE KEY----");

            var record = new PSObject();
            record.Properties.Add(new PSVariableProperty(new PSVariable("Subject", x500)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("KeyCredentials", manifestEntry)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("Certificate", certificateBuilder.ToString())));
            record.Properties.Add(new PSVariableProperty(new PSVariable("PrivateKey", privateKeyBuilder.ToString())));

            WriteObject(record);
        }
    }
}
