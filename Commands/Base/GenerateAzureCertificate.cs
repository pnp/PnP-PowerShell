using System.Management.Automation;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using SharePointPnP.PowerShell.Commands.Utilities;

namespace SharePointPnP.PowerShell.Commands.Base
{
    [Cmdlet("Generate", "PnPAzureCertificate", DefaultParameterSetName = "")]
    [CmdletHelp(@"Get PEM values for an existing certificate (.pfx), or generate a new 2048bit self-signed certificate and manifest for use when using CSOM via an app-only ADAL application.

See https://github.com/SharePoint/PnP-PowerShell/tree/master/Samples/SharePoint.ConnectUsingAppPermissions for a sample on how to get started.

KeyCredentials contains the ADAL app manifest sections.

Certificate contains the PEM encoded certificate.

PrivateKey contains the PEM encoded private key of the certificate.",
        Category = CmdletHelpCategory.Base)]
    [CmdletExample(
        Code = @"PS:> Generate-PnPAzureCertificate",
        Remarks = @"This will generate a default self-signed certificate named ""pnp.contoso.com"" valid for 10 years.",
        SortOrder = 1)]
    [CmdletExample(
        Code = @"PS:> Generate-PnPAzureCertificate -out mycert.pfx ",
        Remarks = @"This will generate a default self-signed certificate named ""pnp.contoso.com"" valid for 10 years and the certificate is stored mycert.pfx without a password in the current directory.",
        SortOrder = 2)]
    [CmdletExample(
        Code = @"PS:> Generate-PnPAzureCertificate -CommonName ""My Certificate"" -ValidYears 30 ",
        Remarks = @"This will output a certificate named ""My Certificate"" which expires in 30 years from now.",
        SortOrder = 3)]
    [CmdletExample(
        Code = @"PS:> Generate-PnPAzureCertificate -CertificatePath ""mycert.pfx""",
        Remarks = @"This will output PEM values and ADAL app manifest settings for the certificate mycert.pfx.",
        SortOrder = 4)]
    [CmdletExample(
        Code = @"PS:> Generate-PnPAzureCertificate -CertificatePath ""mycert.pfx"" -CertificatePassword (ConvertTo-SecureString -String ""YourPassword"" -AsPlainText -Force)",
        Remarks = @"This will output PEM values and ADAL app manifest settings for the certificate mycert.pfx which has the password YourPassword.",
        SortOrder = 5)]
    public class GeneratePnPAdalCertificate : PSCmdlet
    {
        private const string ParameterSet_SELFSIGNED = "SELF";
        private const string ParameterSet_PFX = "PFX";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Common Name (e.g. server FQDN or YOUR name) [pnp.contoso.com]", Position = 0)]
        public string CommonName = "pnp.contoso.com";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Country Name (2 letter code)", Position = 1)]
        public string Country = String.Empty;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "State or Province Name (full name)", Position = 2)]
        public string State = string.Empty;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Locality Name (eg, city)", Position = 3)]
        public string Locality = string.Empty;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Organization Name (eg, company)", Position = 4)]
        public string Organization = string.Empty;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Organizational Unit Name (eg, section)", Position = 5)]
        public string OrganizationUnit = string.Empty;

        [Parameter(Mandatory = false, HelpMessage = "Filename to write to, optionally including full path (.pfx)", Position = 6)]
        public string Out;


        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_SELFSIGNED, HelpMessage = "Number of years until expiration (default is 10, max is 30)", Position = 6)]
        public int ValidYears = 10;

        [Parameter(Mandatory = true, ParameterSetName = ParameterSet_PFX, HelpMessage = "Path to the certificate (*.pfx)")]
        public string CertificatePath;

        [Parameter(Mandatory = false, ParameterSetName = ParameterSet_PFX, HelpMessage = "Password to the certificate (*.pfx)")]
        public SecureString CertificatePassword;


        protected override void ProcessRecord()
        {
            X509Certificate2 certificate;
            if (ParameterSetName == ParameterSet_SELFSIGNED)
            {
                var x500Values = new List<string>();
                if (!string.IsNullOrWhiteSpace(CommonName)) x500Values.Add($"CN={CommonName}");
                if (!string.IsNullOrWhiteSpace(Country)) x500Values.Add($"C={Country}");
                if (!string.IsNullOrWhiteSpace(State)) x500Values.Add($"S={State}");
                if (!string.IsNullOrWhiteSpace(Locality)) x500Values.Add($"L={Locality}");
                if (!string.IsNullOrWhiteSpace(Organization)) x500Values.Add($"O={Organization}");
                if (!string.IsNullOrWhiteSpace(OrganizationUnit)) x500Values.Add($"OU={OrganizationUnit}");

                string x500 = string.Join("; ", x500Values);

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

            if (!string.IsNullOrWhiteSpace(Out))
            {
                if (!Path.IsPathRooted(Out))
                {
                    Out = Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Out);
                }
                byte[] certData = certificate.Export(X509ContentType.Pfx);
                File.WriteAllBytes(Out, certData);
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
            record.Properties.Add(new PSVariableProperty(new PSVariable("Certificate", CertificateHelper.CertificateToBase64(certificate))));
            record.Properties.Add(new PSVariableProperty(new PSVariable("PrivateKey", CertificateHelper.PrivateKeyToBase64(certificate))));

            WriteObject(record);
        }
    }
}
