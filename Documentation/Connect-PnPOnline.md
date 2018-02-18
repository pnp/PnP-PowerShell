---
external help file:
applicable: SharePoint Server 2013, SharePoint Server 2016, SharePoint Online
schema: 2.0.0
---
# Connect-PnPOnline

## SYNOPSIS
Connect to a SharePoint site

## SYNTAX 

### 
```powershell
Connect-PnPOnline [-ReturnConnection [<SwitchParameter>]]
                  [-Url <String>]
                  [-Credentials <CredentialPipeBind>]
                  [-CurrentCredentials [<SwitchParameter>]]
                  [-UseAdfs [<SwitchParameter>]]
                  [-MinimalHealthScore <Int>]
                  [-RetryCount <Int>]
                  [-RetryWait <Int>]
                  [-RequestTimeout <Int>]
                  [-Realm <String>]
                  [-AppId <String>]
                  [-AppSecret <String>]
                  [-UseWebLogin [<SwitchParameter>]]
                  [-AuthenticationMode <ClientAuthenticationMode>]
                  [-CreateDrive [<SwitchParameter>]]
                  [-DriveName <String>]
                  [-SPOManagementShell [<SwitchParameter>]]
                  [-ClientId <String>]
                  [-RedirectUri <String>]
                  [-Tenant <String>]
                  [-CertificatePath <String>]
                  [-CertificatePassword <SecureString>]
                  [-ClearTokenCache [<SwitchParameter>]]
                  [-AzureEnvironment <AzureEnvironment>]
                  [-Scopes <String[]>]
                  [-AADDomain <String>]
                  [-AccessToken <String>]
                  [-TenantAdminUrl <String>]
                  [-SkipTenantAdminCheck [<SwitchParameter>]]
                  [-IgnoreSslErrors [<SwitchParameter>]]
```

## DESCRIPTION
If no credentials have been specified, and the CurrentCredentials parameter has not been specified, you will be prompted for credentials.

## EXAMPLES

### ------------------EXAMPLE 1------------------
```powershell
PS:> Connect-PnPOnline -Url https://contoso.sharepoint.com
```

This will prompt for username and password and creates a context for the other PowerShell commands to use. When a generic credential is added to the Windows Credential Manager with https://contoso.sharepoint.com, PowerShell will not prompt for username and password.

### ------------------EXAMPLE 2------------------
```powershell
PS:> Connect-PnPOnline -Url https://contoso.sharepoint.com -Credentials (Get-Credential)
```

This will prompt for username and password and creates a context for the other PowerShell commands to use. 

### ------------------EXAMPLE 3------------------
```powershell
PS:> Connect-PnPOnline -Url http://yourlocalserver -CurrentCredentials
```

This will use the current user credentials and connects to the server specified by the Url parameter.

### ------------------EXAMPLE 4------------------
```powershell
PS:> Connect-PnPOnline -Url http://yourlocalserver -Credentials 'O365Creds'
```

This will use credentials from the Windows Credential Manager, as defined by the label 'O365Creds'.

### ------------------EXAMPLE 5------------------
```powershell
PS:> Connect-PnPOnline -Url http://yourlocalserver -Credentials (Get-Credential) -UseAdfs
```

This will prompt for username and password and creates a context using ADFS to authenticate.

### ------------------EXAMPLE 6------------------
```powershell
PS:> Connect-PnPOnline -Url https://yourserver -Credentials (Get-Credential) -CreateDrive
cd SPO:\\
dir
```

This will prompt you for credentials and creates a context for the other PowerShell commands to use. It will also create a SPO:\\ drive you can use to navigate around the site

### ------------------EXAMPLE 7------------------
```powershell
PS:> Connect-PnPOnline -Url https://yourserver -Credentials (Get-Credential) -AuthenticationMode FormsAuthentication
```

This will prompt you for credentials and creates a context for the other PowerShell commands to use. It assumes your server is configured for Forms Based Authentication (FBA)

### ------------------EXAMPLE 8------------------
```powershell
PS:> Connect-PnPOnline -Url https://contoso.sharepoint.de -AppId 344b8aab-389c-4e4a-8fa1-4c1ae2c0a60d -AppSecret a3f3faf33f3awf3a3sfs3f3ss3f4f4a3fawfas3ffsrrffssfd -AzureEnvironment Germany
```

This will authenticate you to the German Azure environment using the German Azure endpoints for authentication

### ------------------EXAMPLE 9------------------
```powershell
PS:> Connect-PnPOnline -Url https://contoso.sharepoint.com -SPOManagementShell
```

This will authenticate you using the SharePoint Online Management Shell application

### ------------------EXAMPLE 10------------------
```powershell
PS:> Connect-PnPOnline -Url https://contoso.sharepoint.com -AccessToken $myaccesstoken
```

This will authenticate you using the provided access token

### ------------------EXAMPLE 11------------------
```powershell
PS:> Connect-PnPOnline -Scopes $arrayOfScopes
```

Connects to Azure AD and gets and OAuth 2.0 Access Token to consume the Microsoft Graph API including the declared permission scopes. The available permission scopes are defined at the following URL: https://graph.microsoft.io/en-us/docs/authorization/permission_scopes

### ------------------EXAMPLE 12------------------
```powershell
PS:> Connect-PnPOnline -AppId '<id>' -AppSecret '<secret>' -AADDomain 'contoso.onmicrosoft.com'
```

Connects to the Microsoft Graph API using application permissions via an app's declared permission scopes. See https://github.com/SharePoint/PnP-PowerShell/tree/master/Samples/Graph.ConnectUsingAppPermissions for a sample on how to get started.

## PARAMETERS

### -AADDomain


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AccessToken


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AppId


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AppSecret


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AuthenticationMode


```yaml
Type: ClientAuthenticationMode
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -AzureEnvironment


```yaml
Type: AzureEnvironment
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -CertificatePassword


```yaml
Type: SecureString
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -CertificatePath


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ClearTokenCache


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ClientId


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -CreateDrive


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Credentials


```yaml
Type: CredentialPipeBind
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -CurrentCredentials


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -DriveName


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -IgnoreSslErrors


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -MinimalHealthScore


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Realm


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RedirectUri


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RequestTimeout


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RetryCount


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -RetryWait


```yaml
Type: Int
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -ReturnConnection


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Scopes


```yaml
Type: String[]
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SkipTenantAdminCheck


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -SPOManagementShell


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Tenant


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -TenantAdminUrl


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -Url


```yaml
Type: String
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -UseAdfs


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

### -UseWebLogin


```yaml
Type: SwitchParameter
Parameter Sets: 

Required: False
Position: 0
Accept pipeline input: False
```

## RELATED LINKS

[SharePoint Developer Patterns and Practices](http://aka.ms/sppnp)