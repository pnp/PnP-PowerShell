<# 
----------------------------------------------------------------------------

Deploys resources to Azure Automation, Installs PnP PowerShell, Creates an Azure AD App

Created:      Paul Bullock
Date:         10/08/2020
Disclaimer:   

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

.Notes

    Default App Scopes: Sites.FullControl.All, Group.ReadWrite.All, User.Read.All

    References: 
        https://docs.microsoft.com/en-us/powershell/module/sharepoint-pnp/initialize-pnppowershellauthentication?view=sharepoint-ps
        https://docs.microsoft.com/en-us/powershell/module/az.automation/New-AzAutomationCredential?view=azps-4.4.0

    Due credit to sources, some learnings in the script came from:
        https://github.com/OfficeDev/microsoft-teams-apps-requestateam

 ----------------------------------------------------------------------------
#>

[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [string] $Tenant, #yourtenant.onmicrosoft.com

    [Parameter(Mandatory = $true)]
    [string] $SPTenant, # https://[thispart].sharepoint.com

    [Parameter(Mandatory = $true)]
    [string] $CertificatePassword, # <-- Use a nice a super complex password

    [Parameter(Mandatory = $true)]
    [string] $AzureAppId,

    [Parameter(Mandatory = $true)]
    [string] $CertificatePath, # e.g. "C:\Git\tfs\Script-Library\Azure\Automation\Deploy\PnP-PowerShell Automation.pfx"

    [Parameter(Mandatory = $false)]
    [string] $AzureResourceGroupName = "pnp-powershell-automation-rg",

    [Parameter(Mandatory = $false)]
    [string] $AzureRegion = "northeurope",

    [Parameter(Mandatory = $false)]
    [string] $AzureAutomationName = "pnp-powershell-auto",

    [Parameter(Mandatory = $false)]
    [switch] $CreateResourceGroup
)
begin{


    Write-Host "Let's get started..."
  
    # This cna be a one-time setup - no one needs to know the password, it can be easily replaced
    # in the App and Automation Service if required
    $securePassword = (ConvertTo-SecureString -String $CertificatePassword -AsPlainText -Force)
    
}
process {

    # ----------------------------------------------------------------------------------
    #   Azure - Connect to Azure
    # ----------------------------------------------------------------------------------
    Write-Host " - Connecting to Azure..." -ForegroundColor Cyan
    Connect-AzAccount

     # ----------------------------------------------------------------------------------
    #   Azure - Resource Group
    # ----------------------------------------------------------------------------------

    # Check if the Resource Group exists
    if($CreateResourceGroup){
        Write-Host " - Creating Resource Group..." -ForegroundColor Cyan
        New-AzResourceGroup -Name $AzureResourceGroupName -Location $AzureRegion
    }
        

    # ----------------------------------------------------------------------------------
    #   Azure Automation - Creation
    # ----------------------------------------------------------------------------------

    # Validate this does not already exist
    $existingAzAutomation = Get-AzAutomationAccount | Where-Object AutomationAccountName -eq $AzureAutomationName
    if ($null -ne $existingAzAutomation) {
        Write-Error " - Automation account already exists...aborting deployment script" # Stop the script, already exists
        return #End the Script
    }

    Write-Host " - Creating Azure Automation Account..." -ForegroundColor Cyan

    # Note: Not all regions support Azure Automation - check here for your region: 
    #   https://azure.microsoft.com/en-us/global-infrastructure/services/?products=automation&regions=all
    New-AzAutomationAccount `
        -Name $AzureAutomationName `
        -Location $AzureRegion `
        -ResourceGroupName $AzureResourceGroupName

    # ----------------------------------------------------------------------------------
    #   Azure Automation - Add Modules
    # ----------------------------------------------------------------------------------
    
    # Add PnP Modules - July 2020 Onwards
    New-AzAutomationModule `
        -AutomationAccountName $AzureAutomationName `
        -Name "SharePointPnPPowerShellOnline" `
        -ContentLink "https://devopsgallerystorage.blob.core.windows.net/packages/sharepointpnppowershellonline.3.23.2007.1.nupkg" `
        -ResourceGroupName $AzureResourceGroupName

    
    # ----------------------------------------------------------------------------------
    #   Azure Automation - Create variables
    # ----------------------------------------------------------------------------------
    New-AzAutomationVariable `
        -AutomationAccountName $AzureAutomationName `
        -Name "AppClientId" `
        -Encrypted $False `
        -Value $AzureAppId `
        -ResourceGroupName $AzureResourceGroupName
    
    New-AzAutomationVariable `
        -AutomationAccountName $AzureAutomationName `
        -Name "AppAdTenant" `
        -Encrypted $true `
        -Value $Tenant `
        -ResourceGroupName $AzureResourceGroupName

    New-AzAutomationVariable `
        -AutomationAccountName $AzureAutomationName `
        -Name "App365Tenant" `
        -Encrypted $true `
        -Value $SPTenant `
        -ResourceGroupName $AzureResourceGroupName

    New-AzAutomationCertificate `
        -Name "AzureAppCertificate" `
        -Description "Certificate for PnP PowerShell automation" `
        -Password $securePassword `
        -Path $CertificatePath `
        -Exportable `
        -ResourceGroupName $AzureResourceGroupName `
        -AutomationAccountName $AzureAutomationName

    # In this example, we do not use the UserName part
    $User = "IAamNotUsed"
    $Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $User, $securePassword
    New-AzAutomationCredential `
        -Name "AzureAppCertPassword" `
        -Description "Contains the password for the certificate" `
        -Value $Credential `
        -ResourceGroupName $AzureResourceGroupName `
        -AutomationAccountName $AzureAutomationName `

    # Add Azure Runbook
    Write-Host " - Importing and publishing example runbook..." -ForegroundColor Cyan

    # Import automation runbooks
    $exampleRunbookName = "test-connection-runbook"

    # Add the example runbook into Azure Automation
    Import-AzAutomationRunbook `
        -Name $exampleRunbookName `
        -Path "./$($exampleRunbookName).ps1" `
        -ResourceGroupName $AzureResourceGroupName `
        -AutomationAccountName $AzureAutomationName `
        -Type PowerShell

    # Publish runbooks
    Publish-AzAutomationRunbook `
        -Name $exampleRunbookName `
        -ResourceGroupName $AzureResourceGroupName `
        -AutomationAccountName $AzureAutomationName

    Write-Host "Finished adding example runbook" -ForegroundColor Green
    
}
end{

  Write-Host "Script all done, enjoy! :)" -ForegroundColor Green
}