# Connect to the SharePoint Online using Application Permissions

This PowerShell sample demonstrates how to deploy and use the PnP PowerShell to connect to SharePoint Online
using App-Only within Azure Automation. This is useful for demonstrating connecting to SharePoint Online with App-Only permissions
as well as provisioning Azure Automation with the required modules.

Applies to

- Office 365 Multi-Tenant (MT)

## Prerequisites

- PnP PowerShell Module (Minimum 3.23.2007.1)
- Azure AD - Global Admin (for app consent)
- Azure PowerShell Module	[https://docs.microsoft.com/en-us/powershell/azure/install-az-ps?view=azps-4.4.0](https://docs.microsoft.com/en-us/powershell/azure/install-az-ps?view=azps-4.4.0)

## Scripts

The following script samples as part of the solution:

- Deploy-AzureAppOnly.ps1 - this uses the new cmdlet "Initialize-PnPPowerShellAuthentication" to create the certificate and create Azure AD app
- Deploy-AzureAutomation.ps1 - this creates an Azure Automation account, configures the account for hosting credentials, registering the PnP module and publishing a runbook
- Deploy-FullAutomation.ps1 - this is a combination of both above scripts in one run
- test-connection-runbook.ps1 - sample runbook that connects to SharePoint Online with a certificate and example connections to tenant level and site level 

### Note

Not all regions support Azure Automation - check here for your region: [https://azure.microsoft.com/en-us/global-infrastructure/services/?products=automation&regions=all](https://azure.microsoft.com/en-us/global-infrastructure/services/?products=automation&regions=all)

## Getting Started

### Example 1: Creation of an Azure AD App

```powershell

./Deploy-AzureAppOnly.ps1 `
    -Tenant "yourtenant.onmicrosoft.com" `
    -SPTenant "yourtenant" `
    -AppName "PnP-PowerShell Automation" `
    -CertificatePassword "<Password>"  `
    -ValidForYears 2 `
    -CertCommonName "PnP-PowerShell Automation"

Note: It is recommended to use a better Certificate Password than above, nice and super complex

```

### Example 2: Provisioning Azure Automation with PnP Module, credentials and publishing runbook

```powershell

./Deploy-AzureAutomation.ps1 `
    -Tenant "yourtenant.onmicrosoft.com" `
    -SPTenant "yourtenant" `
    -CertificatePassword "<Password>"  `
    -AzureAppId "b80b83e9-2d52-4aa4-910a-099c296b36d4" `
    -CertificatePath "C:\Git\tfs\Script-Library\Azure\Automation\Deploy\PnP-PowerShell Automation.pfx" `
    -AzureResourceGroupName "pnp-powershell-automation-rg" `
    -AzureRegion "northeurope" `
    -AzureAutomationName "pnp-powershell-auto" `
    -CreateResourceGroup

```

Notes:
- Use a better Certificate Password than above but the same as the one in example 1, nice and super complex
- The CertificatePath is the location where the certificate was stored locally in example 1

### Example 3: Combination Script of both Example 1 and 2

```powershell

./Deploy-FullAutomation.ps1 `
    -Tenant "yourtenant.onmicrosoft.com" `
    -SPTenant "yourtenant" `
    -AppName "PnP-PowerShell Automation" `
    -CertificatePassword "<Password>" `
    -ValidForYears 2 `
    -CertCommonName "PnP-PowerShell Automation" `
    -AzureResourceGroupName "pnp-powershell-automation-rg" `
    -AzureRegion "northeurope"  `
    -AzureAutomationName "pnp-powershell-auto"  `
    -CreateResourceGroup
```

## Version history ##
Version  | Date | Author(s) | Comments
---------| ---- | --------- | ---------|
1.0  | August 10th 2020 | Paul Bullock (CaPa Creative Ltd) | Initial release


## **Disclaimer** 
THIS CODE IS PROVIDED AS IS WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.