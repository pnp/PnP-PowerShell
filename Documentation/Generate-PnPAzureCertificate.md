---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Generate-PnPAzureCertificate

## SYNOPSIS
Get PEM values for an existing certificate (.pfx), or generate a new 2048bit self-signed certificate and manifest for use when using CSOM via an app-only ADAL application.

See https://github.com/SharePoint/PnP-PowerShell/tree/master/Samples/SharePoint.ConnectUsingAppPermissions for a sample on how to get started.

KeyCredentials contains the ADAL app manifest sections.

Certificate contains the PEM encoded certificate.

PrivateKey contains the PEM encoded private key of the certificate.

## SYNTAX 

### SELF
```powershell
Generate-PnPAzureCertificate [-CommonName <String>]
                             [-Country <String>]
                             [-State <String>]
                             [-Locality <String>]
                             [-Organization <String>]
                             [-OrganizationUnit <String>]
                             [-ValidYears <Int>]
                             [-Out <String>]
```

### PFX
```powershell
Generate-PnPAzureCertificate -CertificatePath <String>
                             [-CertificatePassword <SecureString>]
                             [-Out <String>]
```

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Generate-PnPAzureCertificate
```

This will generate a default self-signed certificate named "pnp.contoso.com" valid for 10 years.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Generate-PnPAzureCertificate -out mycert.pfx 
```

This will generate a default self-signed certificate named "pnp.contoso.com" valid for 10 years and the certificate is stored mycert.pfx without a password in the current directory.

### ------------------EXAMPLE 3------------------
```powershell
PS:> Generate-PnPAzureCertificate -CommonName "My Certificate" -ValidYears 30 
```

This will output a certificate named "My Certificate" which expires in 30 years from now.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Generate-PnPAzureCertificate -CertificatePath "mycert.pfx"
```

This will output PEM values and ADAL app manifest settings for the certificate mycert.pfx.

### ------------------EXAMPLE 5------------------
```powershell
PS:> Generate-PnPAzureCertificate -CertificatePath "mycert.pfx" -CertificatePassword (ConvertTo-SecureString -String "YourPassword" -AsPlainText -Force)
```

This will output PEM values and ADAL app manifest settings for the certificate mycert.pfx which has the password YourPassword.

## PARAMETERS

### -CertificatePassword
Password to the certificate (*.pfx)

```yaml
Type: SecureString
Parameter Sets: PFX

Required: False
Position: Named
Accept pipeline input: False
```

### -CertificatePath
Path to the certificate (*.pfx)

```yaml
Type: String
Parameter Sets: PFX

Required: True
Position: Named
Accept pipeline input: False
```

### -CommonName
Common Name (e.g. server FQDN or YOUR name) [pnp.contoso.com]

```yaml
Type: String
Parameter Sets: SELF

Required: False
Position: 0
Accept pipeline input: False
```

### -Country
Country Name (2 letter code)

```yaml
Type: String
Parameter Sets: SELF

Required: False
Position: 1
Accept pipeline input: False
```

### -Locality
Locality Name (eg, city)

```yaml
Type: String
Parameter Sets: SELF

Required: False
Position: 3
Accept pipeline input: False
```

### -Organization
Organization Name (eg, company)

```yaml
Type: String
Parameter Sets: SELF

Required: False
Position: 4
Accept pipeline input: False
```

### -OrganizationUnit
Organizational Unit Name (eg, section)

```yaml
Type: String
Parameter Sets: SELF

Required: False
Position: 5
Accept pipeline input: False
```

### -Out
Filename to write to, optionally including full path (.pfx)

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: 6
Accept pipeline input: False
```

### -State
State or Province Name (full name)

```yaml
Type: String
Parameter Sets: SELF

Required: False
Position: 2
Accept pipeline input: False
```

### -ValidYears
Number of years until expiration (default is 10, max is 30)

```yaml
Type: Int
Parameter Sets: SELF

Required: False
Position: 6
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)