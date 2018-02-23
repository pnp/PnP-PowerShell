# Base Cmdlets 
Cmdlet|Description|Platform
:-----|:----------|:-------
**[Get&#8209;PnPAppAuthAccessToken](Get-PnPAppAuthAccessToken.md)** |Returns the access token|All
**[Get&#8209;PnPAuthenticationRealm](Get-PnPAuthenticationRealm.md)** |Returns the authentication realm|All
**[Get&#8209;PnPAzureADManifestKeyCredentials](Get-PnPAzureADManifestKeyCredentials.md)** |Return the JSON Manifest snippet for Azure Apps|All
**[Generate&#8209;PnPAzureCertificate](Generate-PnPAzureCertificate.md)** |Get PEM values for an existing certificate (.pfx), or generate a new 2048bit self-signed certificate and manifest for use when using CSOM via an app-only ADAL application.  See https://github.com/SharePoint/PnP-PowerShell/tree/master/Samples/SharePoint.ConnectUsingAppPermissions for a sample on how to get started.  KeyCredentials contains the ADAL app manifest sections.  Certificate contains the PEM encoded certificate.  PrivateKey contains the PEM encoded private key of the certificate.|All
**[Get&#8209;PnPConnection](Get-PnPConnection.md)** |Returns the current context|All
**[Get&#8209;PnPContext](Get-PnPContext.md)** |Returns the current context|All
**[Set&#8209;PnPContext](Set-PnPContext.md)** |Set the ClientContext|All
**[Get&#8209;PnPHealthScore](Get-PnPHealthScore.md)** |Retrieves the healthscore|All
**[Connect&#8209;PnPOnline](Connect-PnPOnline.md)** |Connect to a SharePoint site|All
**[Disconnect&#8209;PnPOnline](Disconnect-PnPOnline.md)** |Disconnects the context|All
**[Get&#8209;PnPProperty](Get-PnPProperty.md)** |Returns a previously not loaded property of a ClientObject|All
**[Execute&#8209;PnPQuery](Execute-PnPQuery.md)** |Execute the current queued actions|All
**[Add&#8209;PnPStoredCredential](Add-PnPStoredCredential.md)** |Adds a credential to the Windows Credential Manager|All
**[Get&#8209;PnPStoredCredential](Get-PnPStoredCredential.md)** |Get a credential|All
**[Remove&#8209;PnPStoredCredential](Remove-PnPStoredCredential.md)** |Removes a credential|All
**[Set&#8209;PnPTraceLog](Set-PnPTraceLog.md)** |Turn log tracing on or off|All
