using System.Management.Automation;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using SharePointPnP.PowerShell.Commands.Utilities;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet("Generate", "PnPAdalCertificate", DefaultParameterSetName = "")]
    [CmdletHelp(@"Get PEM values for an existing certificate (.pfx), or generate a new self-signed app-only ADAL certificate and manifest for use when using CSOM via an ADAL application.",
        Category = CmdletHelpCategory.Base)]
    [CmdletExample(
        Code = @"PS:> Generate-PnPAdalCertificate",
        Remarks = @"This will put the current context in the $ctx variable.",
        SortOrder = 1)]
    public class GeneratePnPAdalCertificate : PSCmdlet
    {
        private const string ParameterSet_SELFSIGNED = "SELF";
        private const string ParameterSet_PFX = "PFX";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Common Name (e.g. server FQDN or YOUR name)", Position = 0)]
        public string CommonName = "pnp.contoso.com";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Country Name (2 letter code) [NO]", Position = 1)]
        public string Country = "NO";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "State or Province Name (full name)", Position = 2)]
        public string State = string.Empty;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Locality Name (eg, city)", Position = 3)]
        public string Locality = string.Empty;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Organization Name (eg, company) [PnP]", Position = 4)]
        public string Organization = "PnP";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Organizational Unit Name (eg, section)", Position = 5)]
        public string OrganizationUnit = "PnPPosh";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Number of years until expiration (default is 10, max is 30)", Position = 6)]
        public int ValidYears = 10;

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_PFX, HelpMessage = "Path to the certificate (*.pfx)")]
        public string CertificatePath;

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_PFX, HelpMessage = "Password to the certificate (*.pfx)")]
        public SecureString CertificatePassword;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_PFX, HelpMessage = "Insert line breaks in base64 encoding", Position = 2)]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Insert line breaks in base64 encoding", Position = 7)]
        public SwitchParameter PEMLinebreaks;

        protected override void ProcessRecord()
        {
            X509Certificate2 certificate;
            if (ParameterSetName == ParameterSet_SELFSIGNED)
            {
                List<string> x500values = new List<string>();
                if (!string.IsNullOrWhiteSpace(CommonName)) x500values.Add($"CN={CommonName}");
                if (!string.IsNullOrWhiteSpace(Country)) x500values.Add($"C={Country}");
                if (!string.IsNullOrWhiteSpace(State)) x500values.Add($"S={State}");
                if (!string.IsNullOrWhiteSpace(Locality)) x500values.Add($"L={Locality}");
                if (!string.IsNullOrWhiteSpace(Organization)) x500values.Add($"O={Organization}");
                if (!string.IsNullOrWhiteSpace(OrganizationUnit)) x500values.Add($"OU={OrganizationUnit}");

                string x500 = string.Join("; ", x500values);

                if (ValidYears < 1 || ValidYears > 30)
                {
                    ValidYears = 10;
                }
                DateTime validFrom = DateTime.Today;
                DateTime validTo = validFrom.AddYears(ValidYears);

                byte[] certificateBytes = CertificateHelper.CreateSelfSignCertificatePfx(x500, validFrom, validTo);
                certificate = new X509Certificate2(certificateBytes, (SecureString)null, X509KeyStorageFlags.Exportable);
            }
            else
            {
                certificate = new X509Certificate2(CertificatePath, CertificatePassword, X509KeyStorageFlags.Exportable);
            }

            var rawCert = certificate.GetRawCertData();
            var base64Cert = Convert.ToBase64String(rawCert);
            var rawCertHash = certificate.GetCertHash();
            var base64CertHash = Convert.ToBase64String(rawCertHash);
            var keyId = Guid.NewGuid();

            var template = @"
{{
    ""customKeyIdentifier"": ""{0}"",
    ""keyId"": ""{1}"",
    ""type"": ""AsymmetricX509Cert"",
    ""usage"": ""Verify"",
    ""value"":  ""{2}""
}}
";
            var manifestEntry = string.Format(template, base64CertHash, keyId, base64Cert);

            var record = new PSObject();
            record.Properties.Add(new PSVariableProperty(new PSVariable("Subject", certificate.Subject)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("ValidFrom", certificate.NotBefore)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("ValidTo", certificate.NotAfter)));

            record.Properties.Add(new PSVariableProperty(new PSVariable("KeyCredentials", manifestEntry)));
            record.Properties.Add(new PSVariableProperty(new PSVariable("Certificate", CertificateHelper.CertificateToBase64(certificate, PEMLinebreaks))));
            record.Properties.Add(new PSVariableProperty(new PSVariable("PrivateKey", CertificateHelper.PrivateKeyToBase64(certificate, PEMLinebreaks))));

            WriteObject(record);
        }
    }
}
