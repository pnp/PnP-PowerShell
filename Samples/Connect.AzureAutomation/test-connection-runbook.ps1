<# ----------------------------------------------------------------------------

Example script connecting to SharePoint Online with a 
    App Only Certificate in Azure Automation

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

---------------------------------------------------------------------------- #>

[CmdletBinding()]
Param
()

# Retrieves from the Azure Automation variables and certificate stores 
# the details for connecting to SharePoint Online
$azureAutomateCreds = Get-AutomationPSCredential -Name 'AzureAppCertPassword'
$appId = Get-AutomationVariable -Name "AppClientId"
$appAdTenant = Get-AutomationVariable -Name "AppAdTenant"
$app365Tenant = Get-AutomationVariable -Name "App365Tenant"
$appCert = Get-AutomationCertificate -Name "AzureAppCertificate"

# Addresses for the tenant
$adminUrl = "https://$app365Tenant-admin.sharepoint.com"
$baseSite = "https://$app365Tenant.sharepoint.com"

# Site Template List

try {
    Write-Verbose "Running Script..."
   
    # Export the certificate and convert into base 64 string
    $base64Cert = [System.Convert]::ToBase64String($appCert.Export([System.Security.Cryptography.X509Certificates.X509ContentType]::Pkcs12))

    # Connect to the standard SharePoint Site
    $siteConn = Connect-PnPOnline -ClientId $appId -CertificateBase64Encoded $base64Cert `
        -CertificatePassword $azureAutomateCreds.Password `
        -Url $baseSite -Tenant $appAdTenant -ReturnConnection
    
    # Connect to the SharePoint Online Admin Service
    $adminSiteConn = Connect-PnPOnline -ClientId $appId -CertificateBase64Encoded $base64Cert `
        -CertificatePassword $azureAutomateCreds.Password `
        -Url $adminUrl -Tenant $appAdTenant -ReturnConnection

    # SharePointy Stuff here
    Write-Verbose "Connected to SharePoint Online Site"
    $web = Get-PnPWeb -Connection $siteConn
    $web.Title

    # SharePointy Adminy Stuff here
    Write-Verbose "Connected to SharePoint Online Admin Centre"
    $tenantSite = Get-PnPTenantSite -Url $baseSite -Connection $adminSiteConn
    $tenantSite.Title

}
catch {
    #Script error
    Write-Error "An error occurred: $($PSItem.ToString())"
}